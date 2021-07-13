using System;
using Xunit;
using API.Template.WebService.Controllers.V1;
using API.Template.Infrastructure.Concrete.Services;
using API.Template.WebService.Test.Mocks;

namespace API.Template.WebService.Test
{
    public class TemplateWebserviceTests
    {
        [Fact]
        async public void GetTemplateOk()
        {
            var TemplateControllerMock = new TemplateController(new TemplateService(new TemplateRepositoryMockOk()));
            var result = await TemplateControllerMock.GetEntity(new Guid());
            Assert.True(((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).StatusCode.Equals(200));
        }
    }
}
