using System;

namespace DelegateTemplates
{
    internal class Program
    {
        private static Action<int> _operationAction;
        private static Predicate<int> _isPositive;
        private static Func<int, int> _operationFunc;

        private static event EventHandler<Help> ItWorks; 

        private static void Main()
        {
            _isPositive = delegate(int i) { return i > 0; };

            _operationAction = FactiorialNoRet;
            _operationFunc = FactiorialRet;
            ItWorks += Program__itWorks;


            PrintFactorial(5,_operationAction);

            Console.WriteLine(ReturnFactorial(5,_operationFunc));

            Console.ReadKey();
        }

        private static void Program__itWorks(object sender, Help e)
        {
            if(sender != null)
                Console.Write($"\n***\nInvoked method : {e.Description} | start value = {e.Start} | result = {e.Result}\n***\n");
        }

        private static void FactiorialNoRet(int x)
        {
            var result = 1;
            for (var i = 1; i <= x; i++)
            {
                result *= i;
            }
            ItWorks?.Invoke(new object(), new Help(x,result,"Get factorial (for Action)"));
            Console.WriteLine(result);
        }

        private static int FactiorialRet(int x)
        {
            var result = 1;
            for (var i = 1; i <= x; i++)
            {
                result *= i;
            }
            ItWorks?.Invoke(new object(), new Help(x, result, "Get factorial (for Func)"));
            return result;
        }

        private static void PrintFactorial(int x, Action<int> operation)
        {
            if (!_isPositive(x))
                return;

            operation(x);
        }

        private static int ReturnFactorial(int x, Func<int, int> operation)
        {
            if (!_isPositive(x))
                return default;

            return operation(x);
        }
    }

    internal class Help : EventArgs
    {
        public int Start { get; private set; }
        public int Result { get; private set; }
        public string Description { get; private set; }

        public Help(int start, int result, string description)
        {
            Start = start;
            Result = result;
            Description = description;
        }
    }
}
