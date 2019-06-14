using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

using UESRPG_Character_Manager.ConsoleInterface;

namespace UESRPG_Character_Manager.GameComponents.Rolls
{
    /// <summary>
    /// The Roll class embodies a simple roll of given dice counts/sides. It may be
    /// extended to provide a more tailored dice rolling experience.
    /// </summary>
    [ExportsCommands]
    public class Roll
    {
        protected Roll(List<int> results, int numberOfDice, int diceSides, int modifier)
        {
            Results = results;
            NumberOfDice = numberOfDice;
            DiceSides = diceSides;
            Modifier = modifier;
        }

        /// <summary>
        /// Perform a Roll with the given dice/parameters
        /// </summary>
        /// <param name="numberOfDice">The number of dice to roll</param>
        /// <param name="diceSides">The number of sides on each die</param>
        /// <param name="modifier">(Optional) A modifier to apply to the dice roll</param>
        /// <returns>The resulting Roll</returns>
        public static Roll RollDice(int numberOfDice, int diceSides, int modifier = 0)
        {
            Random r = new Random();

            List<int> results = new List<int>();
            for(int i = 0; i < numberOfDice; i++)
            {
                results.Add(r.Next(1, diceSides));
            }

            Roll roll = new Roll( results, numberOfDice, diceSides, modifier );
            GlobalConsole.Instance.WriteLine( roll.ToString() );
            return roll;
        }

        /// <summary>
        /// Perform a Roll based on the given dice string (e.g., 2d10-2)
        /// </summary>
        /// <param name="diceToRoll">The dice string</param>
        /// <returns>The resulting Roll</returns>
        public static Roll RollDice(string diceToRoll)
        {
            Regex r = new Regex("(?<numberOfDice>\\d+)d(?<diceSides>\\d+)(?<modifier>[\\+-]?\\d+)?");

            diceToRoll = diceToRoll.Replace(" ", "");
            Match m = r.Match(diceToRoll);

            if ( m.Success )
            {
                int numberOfDice = int.Parse( m.Groups["numberOfDice"].Value );
                int diceSides = int.Parse( m.Groups["diceSides"].Value );
                int modifier = 0;
                if ( m.Groups["modifier"].Success )
                {
                    modifier = int.Parse( m.Groups["modifier"].Value );
                }

                return RollDice( numberOfDice, diceSides, modifier );
            }
            else
            {
                throw new Exception( "The diceToRoll string was improperly formatted" );
            }
        }

        /// <summary>
        /// Exposes RollDice(string) to the GlobalConsole
        /// </summary>
        /// <param name="args">User args, ideally in roll format</param>
        [Command("Roll Dice", "roll", "Rolls the given combination of dice, plus an optional modifier", "roll XdY[+Z]")]
        public static void RollCommand( List<string> args )
        {
            try
            {
                string diceToRoll = "";
                foreach(string s in args)
                {
                    diceToRoll += s;
                }
                Roll r = RollDice( diceToRoll );
            }
            catch( Exception e )
            {
                GlobalConsole.Instance.CommandError( "An error occurred during \"roll\": {0}", e.Message );
            }
        }

        /// <summary>
        /// The number of dice rolled
        /// </summary>
        public int NumberOfDice { get; private set; }

        /// <summary>
        /// The sides on each die rolled
        /// </summary>
        public int DiceSides { get; private set; }

        /// <summary>
        /// The results of each die rolled
        /// </summary>
        public List<int> Results { get; private set; }

        /// <summary>
        /// The modifier that was asked for
        /// </summary>
        public int Modifier { get; private set; }

        /// <summary>
        /// The total result of all factors added together
        /// </summary>
        public int Total
        {
            get
            {
                int i = 0;
                foreach(int r in Results)
                {
                    i += r;
                }
                i += Modifier;
                return i;
            }
        }

        /// <summary>
        /// The format string to use when converting to string. Index 0 is the dice rolled (e.g., 2d10+3).
        /// Index 1 is the total breakdown (e.g., ( 2 + 7 ) + 3 = 12).
        /// </summary>
        /// <returns>The format string to use.</returns>
        protected string rollTextFormatString()
        {
            return "Rolled {0} for an outcome of:\n{1}";
        }

        public override string ToString()
        {
            string roll = string.Format("{0}d{1}", NumberOfDice, DiceSides);

            string results = "(";
            for(int i = 0; i < Results.Count; i++)
            {
                results += Results[i];
                if((i+1) != Results.Count)
                {
                    results += " + ";
                }
            }
            results += ")";

            if (Modifier != 0)
            {
                string modifier = (Modifier > 0) ? string.Format(" + {0}", Modifier) : string.Format(" - {0}", Math.Abs( Modifier ) );
                roll += modifier;
                results += modifier;
            }

            results += " = " + Total;

            return string.Format(rollTextFormatString(), roll, results);
        }
    }
}
