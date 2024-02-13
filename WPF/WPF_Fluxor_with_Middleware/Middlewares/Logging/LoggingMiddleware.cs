using Fluxor;
using Newtonsoft.Json;

namespace BasicConcepts.MiddlewareTutorial.Store.Middlewares.Logging
{
    public class LoggingMiddleware : Middleware
    {
        private IDispatcher? Dispatcher;
        private IStore? Store;

        public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
        {
            Dispatcher = dispatcher;
            Store = store;
            Log(nameof(InitializeAsync));
            return Task.CompletedTask;
        }

        public override void AfterInitializeAllMiddlewares()
        {
            Log(nameof(AfterInitializeAllMiddlewares));
        }

        public override bool MayDispatchAction(object action)
        {
            Log(nameof(MayDispatchAction) + ObjectInfo(action));
            return true;
        }

        public override void BeforeDispatch(object action)
        {
            Log(nameof(BeforeDispatch) + ObjectInfo(action));
        }

        public override void AfterDispatch(object action)
        {
            Log(nameof(AfterDispatch) + ObjectInfo(action));
            Log("\t===========STATE AFTER DISPATCH===========");
            foreach (KeyValuePair<string, IFeature> feature in Store.Features)
            {
                string json = JsonConvert.SerializeObject(feature.Value, Formatting.Indented)
                    .Replace("\n", "\n\t");
                Log("\r\n\t" + feature.Key + ": " + json);
            }
            Log("\n");
        }

        private string ObjectInfo(object obj)
            => ": " + obj.GetType().Name + " " + JsonConvert.SerializeObject(obj, Formatting.Indented);

        private static void Log(string text)
        {
            WPF_Fluxor_with_Middleware.Logging.Log.Add($"Middleware: {text}");
        }
    }

}
