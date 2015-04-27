﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
  /// <summary>
  /// Abstract Handler in chain of responsibility pattern.
  /// </summary>
  public abstract class Logger
  {
    protected LogLevel logMask;

    // The next Handler in the chain
    protected Logger next;

    public Logger(LogLevel mask)
    {
      this.logMask = mask;
    }

    /// <summary>
    /// Sets the Next logger to make a list/chain of Handlers.
    /// </summary>
    public Logger SetNext(Logger nextLogger)
    {
      next = nextLogger;
      return nextLogger;
    }

    public void Message(string msg, LogLevel severity)
    {
      if ((severity & logMask) == severity) //True only if any logMask bits are set in severity
      {
        WriteMessage(msg);
      }
      if (next != null)
      {
        next.Message(msg, severity);
      }
    }

    abstract protected void WriteMessage(string msg);
  }
}
