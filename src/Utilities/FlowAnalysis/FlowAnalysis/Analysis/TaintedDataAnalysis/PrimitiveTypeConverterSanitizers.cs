﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using Analyzer.Utilities.PooledObjects;

namespace Analyzer.Utilities.FlowAnalysis.Analysis.TaintedDataAnalysis
{
    internal static class PrimitiveTypeConverterSanitizers
    {
        /// <summary>
        /// <see cref="SanitizerInfo"/>s for primitive type conversion tainted data sanitizers.
        /// </summary>
        public static ImmutableHashSet<SanitizerInfo> SanitizerInfos { get; }

        static PrimitiveTypeConverterSanitizers()
        {
            var builder = PooledHashSet<SanitizerInfo>.GetInstance();

            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemTextStringBuilder,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: default(string[]),
                sanitizingInstanceMethods: new[] {
                    "Clear",
                });

            string[] parseMethods = new string[] { "Parse", "TryParse" };

            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemBoolean,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: parseMethods);
            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemByte,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: parseMethods);
            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemChar,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: parseMethods);
            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemInt16,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: parseMethods);
            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemInt32,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: parseMethods);
            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemInt64,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: parseMethods);
            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemSingle,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: parseMethods);
            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemDouble,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: parseMethods);
            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemDecimal,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: parseMethods);
            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemDateTime,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: parseMethods);
            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemTimeSpan,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: parseMethods);
            builder.AddSanitizerInfo(
                WellKnownTypeNames.SystemNumber,
                isInterface: false,
                isConstructorSanitizing: false,
                sanitizingMethods: new string[] {
                    "ParseInt32",
                    "ParseInt64",
                    "TryParseInt32",
                    "TryParseInt64"
                });

            SanitizerInfos = builder.ToImmutableAndFree();
        }
    }
}
