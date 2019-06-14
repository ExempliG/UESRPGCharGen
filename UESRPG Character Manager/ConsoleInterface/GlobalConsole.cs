using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UESRPG_Character_Manager.Common;

namespace UESRPG_Character_Manager.ConsoleInterface
{
    /// <summary>
    /// The GlobalConsole class provides an app-wide interface for sending messages for various purposes.
    /// These messages can then be displayed, or commands can be dispatched to appropriate subsystems.
    /// Classes marked with the ExportsCommands attribute will be searched for Command functions to be
    /// invoked from the GlobalConsole.
    /// </summary>
    [ExportsCommands]
    public class GlobalConsole : Singleton<GlobalConsole>
    {
        delegate void Command( List<string> args = null );

        private struct ListCommand
        {
            public string Command;
            public string Name;
            public string Description;
            public string Usage;
            public Command Method;

            public ListCommand( string Command, string Name, string Description, string Usage, Command Method )
            {
                this.Command = Command;
                this.Name = Name;
                this.Description = Description;
                this.Usage = Usage;
                this.Method = Method;
            }
        }
        private Dictionary<string, ListCommand> commands = new Dictionary<string, ListCommand>();

        public List<ConsoleLine> Lines { get; private set; }

        public GlobalConsole()
        {
            Lines = new List<ConsoleLine>();
            PopulateCommandsList();
            Lines.Add( "Welcome to UESRPGCharGen" );
        }

        /// <summary>
        /// Search the App assemblies for classes marked with ExportsCommands. Then, search
        /// those classes for functions marked with Command. Finally, build the ListCommand
        /// from the attribute info.
        /// </summary>
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

        /// <summary>
        /// Called to broadcast the addition of a new ConsoleLine
        /// </summary>
        /// <param name="newLine">The line that was added</param>
        protected void onNewConsoleLine( ConsoleLine newLine )
        {
            ConsoleUpdated?.Invoke( this, new ConsoleUpdatedEventArgs( newLine ) );
        }

        /// <summary>
        /// Process the given string as a command from the User
        /// </summary>
        /// <param name="line">The command text to process</param>
        public void ProcessLine( string line )
        {
            WriteWithType( ConsoleLine.LineType.USER_COMMAND, line );

            // Slice off the first token. This is the command name. The remaining args are passed
            // to the command method itself.
            string[] tokens = line.Split( ' ' );
            string command = tokens.First().ToLower();
            var args = tokens.Skip(1).ToList<string>();
            if( commands.ContainsKey( command ) )
            {
                commands[command].Method.Invoke( args );
            }
            else
            {
                CommandError( "Couldn't find command named \"{0}\"", command );
                ConsoleHelp();
            }
        }

        /// <summary>
        /// Write a system-generated message to the GlobalConsole.
        /// </summary>
        /// <param name="line">The line to write.</param>
        /// <param name="args">Arguments to string.Format</param>
        public void WriteLine( string line = "", params object[] args )
        {
            WriteWithType( ConsoleLine.LineType.GENERATED, line, args );
        }

        /// <summary>
        /// Write a debug logging message to the GlobalConsole.
        /// </summary>
        /// <param name="line">The line to write.</param>
        /// <param name="args">Arguments to string.Format</param>
        public void Log( string line = "", params object[] args )
        {
            WriteWithType( ConsoleLine.LineType.DEBUG, line, args );
        }

        /// <summary>
        /// Write an error message to the GlobalConsole.
        /// </summary>
        /// <param name="line">The line to write.</param>
        /// <param name="args">Arguments to string.Format</param>
        public void WriteError( string line = "", params object[] args )
        {
            WriteWithType( ConsoleLine.LineType.ERROR, line, args );
        }

        /// <summary>
        /// WriteWithType will handle the creation of the ConsoleLine argument from a string and LineType,
        /// splitting the input into multiple lines if necessary.
        /// </summary>
        /// <param name="type">The type of line(s) to write</param>
        /// <param name="output">The string to write</param>
        /// <param name="args">Arguments to string.Format</param>
        private void WriteWithType( ConsoleLine.LineType type, string output = "", params object[] args )
        {
            string[] lines = output.Split( '\n' );
            foreach ( string line in lines )
            {
                string processedLine = "\n" + string.Format( line, args );
                ConsoleLine lineToWrite = new ConsoleLine( processedLine, type );
                Lines.Add( lineToWrite );
                onNewConsoleLine( lineToWrite );
            }
        }

        /// <summary>
        /// ConsoleHelp will either print all the commands to GlobalConsole, or
        /// print detailed information about the supplied command name.
        /// </summary>
        /// <param name="args">(Optional) The command to get help with</param>
        [Command("Help", "help", "Provides help (like right now!)", "help [command]")]
        public static void ConsoleHelp( List<string> args = null )
        {
            if ( args == null )
            {
                printAllCommands();
            }
            else if ( args.Count > 1 )
            {
                Instance.CommandError( "Too many arguments supplied to \"Help\"!" );
            }
            else if ( args.Count == 1 )
            {
                string commandName = args.First();
                printHelpForCommand( commandName );
            }
            else
            {
                printAllCommands();
            }
        }

        /// <summary>
        /// Print out the usage text for a given command
        /// </summary>
        /// <param name="commandName">The command to get help with</param>
        private static void printHelpForCommand( string commandName )
        {
            if ( Instance.commands.ContainsKey( commandName ) )
            {
                ListCommand command = Instance.commands[commandName];
                Instance.WriteLine( string.Format( "Help for \"{0}\"", command.Name ) );
                Instance.WriteLine( command.Description );
                Instance.WriteLine( string.Format( "\tUsage: {0}", command.Usage ) );
            }
            else
            {
                Instance.CommandError( "Couldn't find command named \"{0}\".", commandName );
            }
        }

        /// <summary>
        /// Print out all command names and their command text
        /// </summary>
        private static void printAllCommands()
        {
            foreach ( ListCommand command in Instance.commands.Values )
            {
                Instance.WriteLine( string.Format( "{0} - {1}", command.Command, command.Name ) );
                Instance.WriteLine( string.Format( "\t{0}", command.Description ) );
            }
        }

        /// <summary>
        /// Send an error message from a failed command.
        /// </summary>
        /// <param name="errorMessage">(Optional) The message to send</param>
        /// <param name="args">(Optional) Arguments to string.Format</param>
        public void CommandError( string errorMessage = "", params object[] args )
        {
            if ( errorMessage.Length == 0 )
            {
                WriteError( "Command failed" );
            }
            else
            {
                WriteError( string.Format( "Command failed with error: {0}", string.Format(errorMessage, args ) ) );
            }
        }
    }
}
