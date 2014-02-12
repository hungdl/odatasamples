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

namespace Microsoft.Test.OData.Services.ODataWriterService
{
    using System.Collections.Generic;
    using System.Data.Services;
    using System.IO;
    using System.Linq;
    using System.ServiceModel;
    using System.Xml;
    using Microsoft.Data.Edm;
    using Microsoft.Data.Edm.Csdl;
    using Microsoft.Data.Edm.Validation;
    using Microsoft.Data.OData;
    using BaseService = Microsoft.Test.OData.Services.AstoriaDefaultService.Service;

    [ServiceBehaviorAttribute(IncludeExceptionDetailInFaults = true)]
    public class ODataWriterServiceBase<TDataServiceODataWriter> : BaseService where TDataServiceODataWriter : DataServiceODataWriter
    {
        public ODataWriterServiceBase()
        {
            this.ODataWriterFactory =
                (odataWriter) =>
                {
                    var odataWriterConstructor = typeof(TDataServiceODataWriter).GetConstructors().Single(c => c.GetParameters().Count() == 1 && c.GetParameters().Single().ParameterType == typeof(ODataWriter));
                    var customODataWriter = (TDataServiceODataWriter)odataWriterConstructor.Invoke(new object[] { odataWriter });
                    return customODataWriter;
                };
        }

        public static new void InitializeService(DataServiceConfiguration config)
        {
            BaseService.InitializeService(config);

            config.AnnotationsBuilder =
                (model) =>
                {
                    var xmlReaders = new XmlReader[] { XmlReader.Create(new StringReader(@"
                        <Schema xmlns=""http://schemas.microsoft.com/ado/2009/11/edm"" Namespace=""Microsoft.Test.OData.Services.ODataWriterService"" >
                            <Annotations Target=""Microsoft.Test.OData.Services.AstoriaDefaultService.Customer"">
                                <ValueAnnotation Term=""CustomInstanceAnnotations.Term1"" Bool=""true"" />
                            </Annotations>
                        </Schema>
                        ")) };

                    IEdmModel annotationsModel;
                    IEnumerable<EdmError> errors;
                    bool parsed = CsdlReader.TryParse(xmlReaders, model, out annotationsModel, out errors);
                    if (!parsed)
                    {
                        throw new EdmParseException(errors);
                    }

                    return new IEdmModel[] { annotationsModel };
                };
        }
    }
}
