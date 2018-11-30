using System;
using System.Diagnostics;

namespace CrudEntityFramework.Utilerias
{
    public class Log
    {
        //private readonly WebControlBase loggerBase = new WebControlBase();
        //fecha [Type Exception - Message exception] [level]  class - Mensaje.
        private const string TEMPLATE_MENSAJE = "{0} [{1} - {2}] [{3}] - [{4} - Line {5}] - {6}";
        private const string TEMPLATE_MENSAJE_SE = "{0} [{1}] - {2} - {3}";
        private readonly Type tipoClase;
        //string path = HttpContext.Current.Request.MapPath("~/log/" + fecha + ".txt");
        public Log(Type tipoClase)
        {
            this.tipoClase = tipoClase;
        }

        private void Logger(string level, Exception exception, string mensaje, params object[] parameters)
        {
            string logFormat;
            if (exception == null)
            {
                logFormat = string.Format(TEMPLATE_MENSAJE_SE, DateTime.Now, level, tipoClase.Name, string.Format(mensaje, parameters));
            }
            else
            {
                int line;
                // Get stack trace for the exception with source file information
                try
                {
                    StackTrace st = new StackTrace(exception, true);
                    // Get the top stack frame
                    StackFrame frame = st.GetFrame(0);
                    // Get the line number from the stack frame
                    line = frame.GetFileLineNumber();
                }
                catch (Exception)
                {
                    line = -1;
                }

                logFormat = string.Format(TEMPLATE_MENSAJE, DateTime.Now, exception.GetType().FullName, exception.Message, level, tipoClase.Name, line, string.Format(mensaje, parameters));
            }
            //loggerBase.RegistraLog(logFormat);
            
        }
        public void Info(string mensaje, params object[] parameters)
        {
            Logger("INFO", null, mensaje, parameters);
        }

        public void Info(Exception e, string mensaje, params object[] parameters)
        {
            Logger("INFO", e, mensaje, parameters);
        }

        public void Debug(string mensaje, params object[] parameters)
        {
#if DEBUG
            Logger("DEBUG", null, mensaje, parameters);
#endif
        }

        public void Debug(Exception e, string mensaje, params object[] parameters)
        {
#if DEBUG
            Logger("DEBUG", e, mensaje, parameters);
#endif
        }

        public void Warning(string mensaje, params object[] parameters)
        {
            Logger("WARN", null, mensaje, parameters);
        }

        public void Warning(Exception e, string mensaje, params object[] parameters)
        {
            Logger("WARN", e, mensaje, parameters);
        }

        public void Error(string mensaje, params object[] parameters)
        {
            Logger("ERROR", null, mensaje, parameters);
        }

        public void Error(Exception e, string mensaje, params object[] parameters)
        {
            Logger("ERROR", e, mensaje, parameters);
        }
    }
}
