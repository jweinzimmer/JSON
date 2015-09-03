using System;
using System.Text;

namespace ProviderJSONConverter.Core.Errors
{
    public static class ExceptionBuilder
    {
        public static string BuildException(Exception ex) 
        {
            StringBuilder str = new StringBuilder();
            str.Append("A "+ex.GetType().ToString() + " has ocurred during application execution. See below for details.");
            var stack_trace = ex.StackTrace;
            str.Append("\nException Message: ");
            while (ex != null)
            {
                str.Append(ex.Message + "\n");
                ex = ex.InnerException;
            }
            str.Append("\nStack Trace:\n" + stack_trace + "\n");

            return str.ToString();
        }
    }
}
