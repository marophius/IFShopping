using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging.Correlation
{
    public static class AppBuilderExtensions
    {
        public static WebApplication AddCorrelationMiddleware(this WebApplication app) => (WebApplication)app.UseMiddleware<CorrelationIdMiddleware>();
    }
}
