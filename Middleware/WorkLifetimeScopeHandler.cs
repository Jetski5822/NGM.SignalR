using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using Orchard;
using Orchard.Data;

namespace NGM.SignalR.Middleware {
    public class WorkLifetimeScopeHandler {
        private readonly Func<IDictionary<string, object>, Task> _next;

        public WorkLifetimeScopeHandler(Func<IDictionary<string, object>, Task> next) {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> env) {

            var httpContextBase = (HttpContextBase)env["System.Web.HttpContextBase"];
            var requestContext = (RequestContext)env["System.Web.Routing.RequestContext"];

            var workContextAccessor = (IWorkContextAccessor)requestContext.RouteData.DataTokens["IWorkContextAccessor"];

            using (var scope = workContextAccessor.CreateWorkContextScope(httpContextBase)) {
                var transactionManager = scope.Resolve<ITransactionManager>();
                try {
                    transactionManager.Demand();

                    return _next(env);
                }
                catch {
                    transactionManager.Cancel();
                    throw;
                }
            }
        }
    }
}