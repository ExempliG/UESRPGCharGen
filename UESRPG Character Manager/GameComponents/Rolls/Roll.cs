using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

using UESRPG_Character_Manager.ConsoleInterface;

namespace UESRPG_Character_Manager.GameComponents.Rolls
{
    [ExportsCommands]
    public class Roll
    {
        private Roll(List<int> results, int numberOfDice, int diceSides, int modifier)
        {
            Results = results;
            NumberOfDice = numberOfDice;
            DiceSides = diceSides;
            Modifier = modifier;
        }

        public static Roll RollDice(int numberOfDice, int diceSides, int modifier = 0)
        {
            Random r = new Random();

            List<int> results = new List<int>();
            for(int i = 0; i < numberOfDice; i++)
            {
                results.Add(r.Next(1, diceSides));
            }

            return new Roll(results, numberOfDice, diceSides, modifier);
        }

        public static Roll RollDice(string diceToRoll)
        {
            Regex r = new Regex("(?<numberOfDice>\\d+)d(?<diceSides>\\d+)\\+?(?<modifier>\\d+)?");

            diceToRoll = diceToRoll.Replace(" ", "");
            Match m = r.Match(diceToRoll);

            int numberOfDice = int.Parse(m.Groups["numberOfDice"].Value);
            int diceSides = int.Parse(m.Groups["diceSides"].Value);
            int modifier = 0;
            if( m.Groups["modifier"].Success )
            {
                modifier = int.Parse(m.Groups["modifier"].Value);
            }

            return RollDice(numberOfDice, diceSides, modifier);
        }

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
                GlobalConsole.Instance.WriteLine( r.ToString() );
            }
            catch( IndexOutOfRangeException )
            {
                GlobalConsole.Instance.WriteLine( "An error occurred during \"roll\"" );
            }
        }

        public int NumberOfDice { get; private set; }
        public int DiceSides { get; private set; }
        public List<int> Results { get; private set; }
        public int Modifier { get; private set; }
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
                string modifier = (Modifier > 0) ? string.Format(" + {0}", Modifier) : string.Format(" - {0}", Modifier);
                roll += modifier;
                results += modifier;
            }

            results += " = " + Total;

            return string.Format("Rolled {0} for an outcome of:\n{1}", roll, results);
        }
    }
}
