//   Copyright 2011 Microsoft Corporation
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

namespace Microsoft.Test.OData.Services.PublicProvider
{
    using System.Diagnostics;

    /// <summary>
    /// Log class
    /// </summary>
    internal static class Log
    {
        /// <summary>
        /// Trace to debug TraceSource
        /// </summary>
        /// <param name="args">The arguments to trace</param>
        public static void Trace(params  object[] args)
        {
            string callee = GetCallerIdentity(2);
            string caller = GetCallerIdentity(3);
            string message = string.Empty;
            if (args != null)
            {
                message = string.Join(" ", args);
            }
            System.Diagnostics.Trace.WriteLine(string.Format("{0}, {1}, {2}", caller, callee, message));
        }

        /// <summary>
        /// Get the caller identity from the stacktrace
        /// </summary>
        /// <param name="skipFrames">The level of stack frame to skip</param>
        /// <returns>The caller function</returns>
        private static string GetCallerIdentity(int skipFrames)
        {
            var frame = new StackFrame(skipFrames, true);
            if (null != frame.GetMethod() && null != frame.GetMethod().DeclaringType)
            {
                return string.Format("{0}.{1}", frame.GetMethod().DeclaringType.Name, frame.GetMethod().Name);
            }
            return string.Empty;
        }
    }
}
