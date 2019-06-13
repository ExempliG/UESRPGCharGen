using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UESRPG_Character_Manager.Common;

namespace UESRPG_Character_Manager.ConsoleInterface
{
    [ExportsCommands]
    public class GlobalConsole : Singleton<GlobalConsole>
    {
        delegate void Command( List<string> args = null );

        private struct ListCommand
        {
            public string _ArgToken;
            public string _ArgName;
            public string _ArgDescription;
            public string _ArgUsage;
            public Command _ArgMethod;

            public ListCommand( string ArgToken, string ArgName, string ArgDescription, string ArgUsage, Command ArgMethod )
            {
                _ArgToken = ArgToken;
                _ArgName = ArgName;
                _ArgDescription = ArgDescription;
                _ArgUsage = ArgUsage;
                _ArgMethod = ArgMethod;
            }
        }
        private Dictionary<string, ListCommand> commands = new Dictionary<string, ListCommand>();

        public List<string> Lines { get; private set; }

        public GlobalConsole()
        {
            Lines = new List<string>();
            PopulateCommandsList();
            Lines.Add( "Welcome to UESRPGCharGen" );
        }

        void PopulateCommandsList()
        {
            IEnumerable<Type> types = from a in AppDomain.CurrentDomain.GetAssemblies()
                                      from t in a.GetTypes()
                                      where t.IsDefined( typeof( ExportsCommandsAttribute ), false )
                                      select t;
            foreach ( Type t in types )
            {
                // Find all methods with CommandAttributes assigned and select them in a tuple
                var commandsList = from m in t.GetMethods()
                                   from a in Attribute.GetCustomAttributes( m )
                                   where a is CommandAttribute
                                   select new { Method = m, Attribute = ( CommandAttribute )a };

                foreach ( var m in commandsList )
                {
                    Command c = ( Command )Delegate.CreateDelegate( typeof( Command ), m.Method );
                    CommandAttribute info = m.Attribute;
                    string command = info.Command.ToLower();
                    commands.Add( command, new ListCommand( command,
                                                            info.Name,
                                                            info.Help,
                                                            info.Usage,
                                                            c ) );
                }
            }
        }

        public delegate void ConsoleUpdatedHandler( object sender, ConsoleUpdatedEventArgs e );
        [Description( "Fires when the GlobalConsole has new information." )]
        public static event ConsoleUpdatedHandler ConsoleUpdated;

        protected void onConsoleUpdated( string newLine )
        {
            ConsoleUpdated?.Invoke( this, new ConsoleUpdatedEventArgs( newLine ) );
        }

        public void ProcessLine( string line )
        {
            string lineToWrite = "\n" + line;
            Lines.Add( lineToWrite );
            onConsoleUpdated( lineToWrite );

            string[] tokens = line.Split( ' ' );
            string command = tokens.First().ToLower();
            var args = tokens.Skip(1).ToList<string>();
            if( commands.ContainsKey( command ) )
            {
                commands[command]._ArgMethod.Invoke( args );
            }
            else
            {
                CommandError( "Couldn't find command named \"{0}\"", command );
            }
        }

        public void WriteLine( string line = "", params object[] args )
        {
            line = "\n" + string.Format( line, args );
            Lines.Add( line );
            onConsoleUpdated( line );
        }

        [Command("Help", "help", "Provides help (like right now!)", "help [command]")]
        public static void ConsoleHelp( List<string> args )
        {
            if ( args.Count > 1 )
            {
                CommandError( "Too many arguments supplied to \"Help\"!" );
            }
            else if ( args.Count == 1 )
            {
                string commandName = args.First();
                if ( Instance.commands.ContainsKey( commandName ) )
                {
                    ListCommand command = Instance.commands[commandName];
                    Instance.WriteLine( string.Format( "Help for \"{0}\"", command._ArgName ) );
                    Instance.WriteLine( command._ArgDescription );
                    Instance.WriteLine( string.Format( "\tUsage: {0}", command._ArgUsage ) );
                }
                else
                {
                    CommandError( "Couldn't find command named \"{0}\".", commandName );
                }
            }
            else
            {
                foreach ( ListCommand command in Instance.commands.Values )
                {
                    Instance.WriteLine( string.Format( "{0} - {1}", command._ArgToken, command._ArgName ) );
                    Instance.WriteLine( string.Format( "\t{0}", command._ArgDescription ) );
                }
            }
        }

        public static void CommandError( string errorMessage = "", params object[] args )
        {
            if ( errorMessage.Length == 0 )
            {
                Instance.WriteLine( "Command failed" );
            }
            else
            {
                Instance.WriteLine( string.Format( "Command failed with error: {0}", string.Format(errorMessage, args ) ) );
            }
        }
    }
}
