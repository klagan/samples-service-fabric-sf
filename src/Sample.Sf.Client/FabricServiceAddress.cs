using System;
using System.Runtime.Serialization;

namespace Sample.Sf.Client
{
    public class FabricServiceAddress : Uri
    {
        protected FabricServiceAddress(SerializationInfo serializationInfo, StreamingContext streamingContext) 
            : base(serializationInfo, streamingContext) { }

        public FabricServiceAddress(string uriString) 
            : base(uriString) { }
       
        public FabricServiceAddress(string uriString, UriKind uriKind) 
            : base(uriString, uriKind) { }

        public FabricServiceAddress(Uri baseUri, string relativeUri) 
            : base(baseUri, relativeUri) { }
        
        public FabricServiceAddress(Uri baseUri, Uri relativeUri) 
            : base(baseUri, relativeUri) { }
    }
}