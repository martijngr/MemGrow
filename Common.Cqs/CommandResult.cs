using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Common.Cqs
{
    public class CommandResult
    {
        private CommandResult()
        { 
        }

        public dynamic Result { get; private set; }

        public bool Successfull => string.IsNullOrEmpty(FailureReason);

        public string FailureReason { get; private set; }

        public static CommandResult Success() => new CommandResult();

        public static CommandResult Success(dynamic result) => new CommandResult { Result = result };

        public static CommandResult Failure(string reason) => new CommandResult { FailureReason = reason };
    }
}
