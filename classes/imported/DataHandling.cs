using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHangedMan.classes.imported
{
    internal class DataHandling
    {
        /// <summary>
        /// Attempts to transform supplied string to integer. Returns value as integer and a boolean where true means success and false means something went wrong.
        /// </summary>
        /// <param name="parameter">string to be converted</param>
        /// <returns>resulting int + bool</returns>
        public static (int result, bool wasSuccessful) StringToInteger(string parameter)
        {
            if (!String.IsNullOrEmpty(parameter))
            {
                string trimmedParameter = parameter.Trim();

                if (int.TryParse(trimmedParameter.Trim(), out int result))
                {
                    return (result, true);
                }
            }
            return (0, false);
        }
    }
}
