﻿/*
 * This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
 * If a copy of the MPL was not distributed with this file, You can obtain one at
 * http://mozilla.org/MPL/2.0/. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSO.SimsAntics.Engine;
using TSO.Files.utils;

namespace TSO.SimsAntics.Primitives
{
    public class VMTestSimInteractingWith : VMPrimitiveHandler
    {
        public override VMPrimitiveExitCode Execute(VMStackFrame context, VMPrimitiveOperand args)
        {
            //if caller's active interaction is with stack object, return true.
            return (context.Caller.Thread.Queue[0].Callee == context.StackObject)?VMPrimitiveExitCode.GOTO_TRUE:VMPrimitiveExitCode.GOTO_FALSE;
        }
    }

    public class VMTestSimInteractingWithOperand : VMPrimitiveOperand
    {
        #region VMPrimitiveOperand Members
        public void Read(byte[] bytes)
        {
            using (var io = IoBuffer.FromBytes(bytes, ByteOrder.LITTLE_ENDIAN))
            {
                //nothing! zip! zilch! nada!
            }
        }

        public void Write(byte[] bytes) { }
        #endregion
    }
}