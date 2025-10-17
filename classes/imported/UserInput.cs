namespace Bytebasket
{
    /// <summary>
    /// A class containing methods for handling terminal user inputs.
    /// </summary>
    internal class UserInput
    {
        /// <summary>
        /// Ensures the user's input is a valid integer.
        /// </summary>
        /// <returns>Integer</returns>
        public static int Integer()
        {
            int value = 0;
            bool wasSuccessful = false;

            bool stillValidating = true;
            while (stillValidating)
            {
                string? userInput = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInput))
                {
                    string trimmedUserInput = userInput.Trim();
                    wasSuccessful = int.TryParse(trimmedUserInput, out value);
                }

                if (wasSuccessful)
                {
                    stillValidating = false;
                }
                else
                {
                    Thread.Sleep(200);
                    Console.Write("Not a valid number. Try again: ");
                }
            }
            return value;
        }

        /// <summary>
        /// Ensures the user's input is a valid double.
        /// </summary>
        /// <returns>Double</returns>
        public static double Double()
        {
            double value = 0;
            bool wasSuccessful = false;

            bool stillValidating = true;
            while (stillValidating)
            {
                string? userInput = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInput))
                {
                    string trimmedUserInput = userInput.Trim();
                    wasSuccessful = double.TryParse(trimmedUserInput, out value);
                }

                if (wasSuccessful)
                {
                    stillValidating = false;
                }
                else
                {
                    Thread.Sleep(200);
                    Console.Write("Not a valid number. Try again: ");
                }
            }
            return value;
        }

        /// <summary>
        /// Ensures the user's input is a valid double with a positive value.
        /// </summary>
        /// <returns>Double</returns>
        public static double PositiveDouble()
        {
            double value = 0;
            bool wasSuccessful = false;

            bool stillValidating = true;
            while (stillValidating)
            {
                string? userInput = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInput))
                {
                    string trimmedUserInput = userInput.Trim();
                    bool wasNumber = double.TryParse(trimmedUserInput, out value);
                    if (wasNumber)
                    {
                        if (value > 0)
                        {
                            wasSuccessful = true;
                        }
                    }
                }

                if (wasSuccessful)
                {
                    stillValidating = false;
                }
                else
                {
                    Thread.Sleep(200);
                    Console.Write("Not a valid number. Try again: ");
                }
            }
            return value;
        }

        /// <summary>
        /// Ensures the user's input is a valid string and trims it.
        /// </summary>
        /// <returns>String</returns>
        public static string TrimmedString()
        {
            string value = "";
            bool wasSuccessful = false;

            bool stillValidating = true;
            while (stillValidating)
            {
                string? userInput = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInput))
                {
                    value = userInput.Trim();
                    wasSuccessful = true;
                }

                if (wasSuccessful)
                {
                    stillValidating = false;
                }
                else
                {
                    Thread.Sleep(200);
                    Console.Write("Not a valid input. Try again: ");
                }
            }
            return value;
        }



    }
}
