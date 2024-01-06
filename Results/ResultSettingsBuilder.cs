using System;

namespace Results
{
    public class ResultSettingsBuilder
    {
        public IResultLogger Logger { get; set; }

        public Func<Exception, Error> DefaultTryCatchHandler { get; set; }

        public ResultSettingsBuilder()
        {
            Logger = new DefaultLogger();
            DefaultTryCatchHandler = (Exception ex) => new ExceptionalError(ex.Message, ex);
        }

        public ResultSettings Build()
        {
            return new ResultSettings
            {
                Logger = Logger,
                DefaultTryCatchHandler = DefaultTryCatchHandler
            };
        }
    }
}

