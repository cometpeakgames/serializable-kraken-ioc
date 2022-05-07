﻿using System;

namespace CometPeak.SerializableKrakenIoc {
    /// <summary>
    /// Used to decorate static methods or constructors
    /// that the injector will use to resolve the type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method)]
    public class ConstructorAttribute : Attribute {

    }
}
