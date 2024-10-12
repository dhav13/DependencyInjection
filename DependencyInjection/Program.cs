
//Coupling-intro:- High Dependency
//var uIn = new HighCoupling.UserInterface();
//uIn.SignUp();


//Coupling-Reduced
//var uIn = new CoupingReduced.UserInterface();
//uIn.SignUp();


//Basic - DI
//BasicDIAndDIComplete.IDataAccess da = new BasicDIAndDIComplete.OracleDataAccess();
//BasicDIAndDIComplete.IBussiness biz = new BasicDIAndDIComplete.Business(da);
//BasicDIAndDIComplete.UserInterface ui = new BasicDIAndDIComplete.UserInterface(biz);
//ui.SignUp();

//Dependency in full-swing
//Above in "Basic-DI", we were still using new stmts, now we need to eliminate that also.
//This where were Microsoft Extension Depedency Injection package comes into picture.

using Microsoft.Extensions.DependencyInjection;

IServiceCollection services = new ServiceCollection();
services.AddScoped<BasicDIAndDIComplete.IDataAccess, BasicDIAndDIComplete.OracleDataAccess>();
services.AddScoped<BasicDIAndDIComplete.IBussiness, BasicDIAndDIComplete.Business>();
services.AddScoped<BasicDIAndDIComplete.UserInterface>();

IServiceProvider servicesProvider = services.BuildServiceProvider();

BasicDIAndDIComplete.UserInterface ui = servicesProvider.GetRequiredService<BasicDIAndDIComplete.UserInterface>();
ui.SignUp();