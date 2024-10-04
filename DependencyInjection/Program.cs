

//Coupling-intro:- High Dependency
//var uIn = new HighCoupling.UserInterface();
//uIn.SignUp();


//Coupling-Reduced
//var uIn = new CoupingReduced.UserInterface();
//uIn.SignUp();


//Basic-DI
BasicDI.IDataAccess da = new BasicDI.OracleDataAccess();
BasicDI.IBussiness biz = new BasicDI.Business(da);
BasicDI.UserInterface ui = new BasicDI.UserInterface(biz);
ui.SignUp();