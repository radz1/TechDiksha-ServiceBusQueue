Follow these instruction to run this application
1. Prerequisite :
   - Should have a azure account.
   - Should have create a azure service bus resources created. Need to copy Public Connection String of the service bus resource.
   - Should have create a queue inside the service bus. Need to have name of the QUEUE created.

   Steps:
   1. Set QueueSample as Startup project, Then execute. This will send some message to the QUEUE.
   2. To Recieve and see those message, Run QueueMessageReciever as startup project and execute.