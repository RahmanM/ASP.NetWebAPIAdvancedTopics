Good Practices
=======================

- return IHttpActionResult instead of HttpResponseMessage
- use Return OK() or Return InternalServerError(e); instead of Request.CreateResponse(HttpCode.InternalServerError, e)
- To enable we api documentation
> change the project properties to generate xml file by ticking the options
> set the file to go to bin
> uncomment the line in the HelpPageConfig.cs file to include models documentation 
	-> config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/bin/XmlDocument.xml")));
	-> change the path to bin if not already done
> For all the actions add [ResponseType(typeof(IEnumerable<Type_Of_Your_Model>))] so it will be recognized by documentation
> Add XML comments to objects and properties