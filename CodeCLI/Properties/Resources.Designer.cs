﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeCLI.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CodeCLI.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace @Namespace;
        ///
        ///public @IsAbstract @IsSeald class @Name @Inheritance
        ///{
        ///}.
        /// </summary>
        internal static string classTemp {
            get {
                return ResourceManager.GetString("classTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace @Namespace;
        ///
        ///public static class CodeCLIStartup
        ///{
        ///	public static IServiceCollection AddCodeCLIService(this IServiceCollection services, IConfiguration config)
        ///	{
        ///		return services;
        ///	}
        ///
        ///	public static IApplicationBuilder UseCodeCLIService(this IApplicationBuilder builder)
        ///	{
        ///		return builder;
        ///	}
        ///}.
        /// </summary>
        internal static string codeCLIStartupTemp {
            get {
                return ResourceManager.GetString("codeCLIStartupTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace @Namespace;
        ///
        ///public partial class @Name
        ///{
        ///	
        ///}.
        /// </summary>
        internal static string ComponentTemp {
            get {
                return ResourceManager.GetString("ComponentTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using Microsoft.AspNetCore.Mvc;
        ///
        ///namespace @Namespace;
        ///
        ///[ApiController]
        ///[Route(&quot;[controller]&quot;)]
        ///public seald class @Name : BaseController
        ///{
        ///	[HttpGet]
        ///	public IActionResult GetAll()
        ///	{
        ///  		return Ok(default);
        ///	}
        ///
        ///	[HttpGet(&quot;{id}&quot;)]
        ///	public IActionResult GetById(Guid id)
        ///	{
        ///  		return Ok(default);
        ///	}
        ///
        ///	[HttpPost]
        ///	public IActionResult Create([FromBody] string userInput)
        ///	{
        ///  		return Ok(default);
        ///	}
        ///
        ///	[HttpPut(&quot;{id}&quot;)]
        ///	public IActionResult Update([FromQuery] Guid id, [FromBody] st [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string controllerTemp {
            get {
                return ResourceManager.GetString("controllerTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///p {
        ///  font-size: 18px;
        ///  color: #333;
        ///  background-color: #f0f0f0;
        ///  padding: 20px;
        ///  border-radius: 5px;
        ///  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        ///}.
        /// </summary>
        internal static string CssTemp {
            get {
                return ResourceManager.GetString("CssTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace @Namespace;
        ///
        ///public enum @Name
        ///{
        ///}.
        /// </summary>
        internal static string enumTemp {
            get {
                return ResourceManager.GetString("enumTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using MediatR;
        ///
        ///namespace @Namespace;
        ///
        ///public class @NameRequestHandler : IRequestHandler&lt;@NameRequest, @Response&gt;
        ///{
        ///	public Task&lt;@Response&gt; Handle(@NameRequest request, CancellationToken cancellationToken)
        ///	{
        ///		// Implement your logic here
        ///		// Return a response
        ///		return Task.FromResult(new @Response());
        ///	}
        ///}
        ///.
        /// </summary>
        internal static string handlerTemp {
            get {
                return ResourceManager.GetString("handlerTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace @Namespace;
        ///
        ///public interface @Name
        ///{
        ///}.
        /// </summary>
        internal static string interfaceTemp {
            get {
                return ResourceManager.GetString("interfaceTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace @Namespace;
        ///
        ///public class @NameMiddleware : IMiddleware
        ///{
        ///	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        ///	{
        ///		try
        ///		{
        ///			await next.Invoke(context);
        ///		}
        ///		catch (Exception ex)
        ///		{
        ///			// Handle the exception
        ///		}
        ///	}
        ///}.
        /// </summary>
        internal static string middlewareTemp {
            get {
                return ResourceManager.GetString("middlewareTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using Microsoft.AspNetCore.Builder;
        ///using Microsoft.AspNetCore.Mvc;
        ///
        ///namespace @Namespace;
        ///
        ///public static class @Name
        ///{
        ///	public static void Map@NameEndpoints(this WebApplication app)
        ///	{
        ///		//Create
        ///		 app.MapPost(&quot;/Foos&quot;,async (FooRequest fooRequest, IFooService fooService)
        ///			=&gt; await fooService.CreateFoo(fooRequest));
        ///
        ///		 //Read All
        ///		 app.MapGet(&quot;/Foo&quot;, async (IFooService fooService)
        ///			=&gt; await fooService.GetFoos());
        ///
        ///		 //Read by Id
        ///		 app.MapGet(&quot;/Foo/{{id}}&quot;, async (Guid id, IFooServ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string minimalApiTemp {
            get {
                return ResourceManager.GetString("minimalApiTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using MediatR;
        ///namespace @Namespace;
        ///public class @NameEventHandler : INotificationHandler&lt;@NameEvent&gt;
        ///{
        ///	 public async Task Handle(@NameEvent notification, CancellationToken cancellationToken)
        ///	 {
        ///		return Task.CompletedTask;
        ///	 }
        ///}.
        /// </summary>
        internal static string notificationHandler {
            get {
                return ResourceManager.GetString("notificationHandler", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using MediatR;
        ///namespace @Namespace;
        ///
        ///public class @NameEvent : INotification
        ///{
        ///	
        ///}.
        /// </summary>
        internal static string notificationTemp {
            get {
                return ResourceManager.GetString("notificationTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p&gt;
        ///	@Name works!
        ///&lt;/ps&gt;.
        /// </summary>
        internal static string RazorTemp {
            get {
                return ResourceManager.GetString("RazorTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace @Namespace;
        ///
        ///public record @Name() @Inheritance
        ///{
        ///}.
        /// </summary>
        internal static string recordTemp {
            get {
                return ResourceManager.GetString("recordTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using MediatR;
        ///
        ///namespace @Namespace;
        ///
        ///public record @NameRequest : IRequest&lt;@Response&gt;
        ///{
        ///	// Add properties as needed
        ///}
        ///.
        /// </summary>
        internal static string requestTemp {
            get {
                return ResourceManager.GetString("requestTemp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using FluentValidation;
        ///
        ///namespace @Namespace;
        ///
        ///public class @NameValidator : AbstractValidator&lt;@Name&gt;
        ///{
        ///	public @NameValidator()
        ///	{
        ///
        ///	}
        ///}
        ///.
        /// </summary>
        internal static string validatorTemp {
            get {
                return ResourceManager.GetString("validatorTemp", resourceCulture);
            }
        }
    }
}
