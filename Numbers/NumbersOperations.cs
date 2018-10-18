namespace Numbers
{
    public class NumbersOperations
    {
        public static void Main()
        {
        }

        public static double GetSum(double firstNum, double secondNum)
        {
            return firstNum + secondNum;
        }

        public static double GetMultiplication(double firstNum, double secondNum)
        {
            return firstNum * secondNum;
        }

        public static double GetDifference(double firstNum, double secondNum)
        {
            return firstNum - secondNum;
        }

        public static double GetDivision(double firstNum, double secondNum)
        {
            return firstNum / secondNum;
        }

        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}
