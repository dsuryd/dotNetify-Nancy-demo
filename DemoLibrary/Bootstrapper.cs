using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Session;
using Nancy.TinyIoc;

namespace DemoLibrary
{
   public class Bootstrapper : DefaultNancyBootstrapper
   {
      protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
      {
         base.ApplicationStartup(container, pipelines);
         this.Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Scripts"));
         CookieBasedSessions.Enable(pipelines);
      }
   }
}