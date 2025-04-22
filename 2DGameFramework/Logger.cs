using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public class Logger
    {
        private TraceSource _traceSource;
        public static readonly Logger Instance = new Logger();
        private Logger(string name = "Framwork tracer")
        {
            _traceSource = new TraceSource(name);
            _traceSource.Switch = new SourceSwitch(name, SourceLevels.All.ToString());
        }
        /// <summary>
        /// Adds a trace listener, to logging calls
        /// </summary>
        /// <param name="listener">The listener to add. Could be ConsoleTraceListener or TextWriterTraceListener. Remember, you can set their "Filter" to "EventTypeFilter(SourceLevels.<level>)"</param>
        public void AddTraceListener(TraceListener listener)
        {
            _traceSource.Listeners.Add(listener);
        }
        /// <summary>
        /// Removes a trace listener, from the logger
        /// </summary>
        /// <param name="listener"></param>
        public void RemoveTraceListener(TraceListener listener)
        {
            _traceSource.Listeners.Remove(listener);
        }
        /// <summary>
        /// Removes a trace listener, at a given index, from the logger
        /// </summary>
        /// <param name="index"></param>
        public void RemoveTraceListener(int index)
        {
            _traceSource.Listeners.RemoveAt(index);
        }
        /// <summary>
        /// Removes all trace listeners, from the logger
        /// </summary>
        public void RemoveAllTraceListener()
        {
            _traceSource.Listeners.Clear();
        }

        /// <summary>
        /// Stops the loggers trace source, this must be called, before closing the 
        /// application, for some TraceListeners (Text, xml, etc.) to work properly
        /// </summary>
        public void Stop()
        {
            _traceSource.Close();
        }
        /// <summary>
        /// The method to log to all added tracelisteners
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="type">The type of message (Verbose, Information, Warning, Error, Critical)</param>
        public void Log(string message, TraceEventType type)
        {
            _traceSource.TraceEvent(type, 17337, message);
        }
    }
}
