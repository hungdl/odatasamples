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

#region Task 1268242:Address CodeAnalysis suppressions that were added when moving to FxCop for SDL 6.0
// This is non-shipping code so it doesn't technically need to be addressed as part of 1268242, but these suppressions should be reviewed as they were introduced in the build system migration
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Invokable", Scope = "member", Target = "Microsoft.Test.OData.Framework.TestProviders.Contracts.DataServiceActionProviderOverrides.#WithCreateInvokableFunc(System.Func`4<System.Data.Services.DataServiceOperationContext,System.Data.Services.Providers.ServiceAction,System.Object[],System.Data.Services.Providers.IDataServiceInvokable>)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Invokable", Scope = "member", Target = "Microsoft.Test.OData.Framework.TestProviders.Contracts.DataServiceUpdatable2Overrides.#WithImmediateCreateInvokable(System.Action`1<System.Data.Services.Providers.IDataServiceInvokable>)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Invokable", Scope = "member", Target = "Microsoft.Test.OData.Framework.TestProviders.Contracts.DataServiceUpdatable2Overrides.#WithPendingActionsCreateInvokable(System.Action`1<System.Data.Services.Providers.IDataServiceInvokable>)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "type", Target = "Microsoft.Test.OData.Framework.TestProviders.Dictionary.DictionaryDataContext")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "invokable", Scope = "member", Target = "Microsoft.Test.OData.Framework.TestProviders.Dictionary.DictionaryDataContext.#ScheduleInvokable(System.Data.Services.Providers.IDataServiceInvokable)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Invokable", Scope = "member", Target = "Microsoft.Test.OData.Framework.TestProviders.Dictionary.DictionaryDataContext.#ScheduleInvokable(System.Data.Services.Providers.IDataServiceInvokable)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "invokable", Scope = "member", Target = "Microsoft.Test.OData.Framework.TestProviders.Reflection.ReflectionDataContext.#ScheduleInvokable(System.Data.Services.Providers.IDataServiceInvokable)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Invokable", Scope = "member", Target = "Microsoft.Test.OData.Framework.TestProviders.Reflection.ReflectionDataContext.#ScheduleInvokable(System.Data.Services.Providers.IDataServiceInvokable)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Test.OData.Framework.TestProviders.Reflection.ReflectionMetadataHelper.#GetResourceTypesOfSet(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Test.OData.Framework.TestProviders.OptionalProviders.StreamWrapper.#ReadUri")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Invokable", Scope = "type", Target = "Microsoft.Test.OData.Framework.TestProviders.OptionalProviders.TestDataServiceInvokable")]
#endregion
