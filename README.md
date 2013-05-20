Ef6AsyncAndMars
===============

Example app to demonstrate the issue [InvalidOperationException now that MARS is off by default](http://entityframework.codeplex.com/workitem/979) with EF6 beta 3.

Steps to reproduce
------------------

1. Restore all the packages, use the package manager console to ensure the [xunit.runners](http://nuget.org/packages/xunit.runners/1.9.1) package is restored.
1. Build the solution.
1. Run [ExecuteUnitTests.bat](./ExecuteUnitTests.bat) and both tests should fail.
1. Change the [App.config](./Ef6AsyncAndMars/App.config#L11) un-commenting the additional parameter to the connection factory.
1. Rebuild the solution (this ensure the App.config is copied to the bin folder)
1. Run [ExecuteUnitTests.bat](./ExecuteUnitTests.bat) and both tests should pass.
