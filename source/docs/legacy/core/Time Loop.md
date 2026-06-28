Executes the contained activities once and continues to do so for a specified period of time.

![](../img/activities/TimeLoop.png)

##### Properties

|Name              |Description                                                                                                                                                                     |
|------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|ExitOnException   |Exits immediately from the loop in case of an unhandled exception occur.                                                                                                        |
|Index             |The current iteration (zero-based) that is being processed.                                                                                                                     |
|IsTimeout         |Determines if the time loop reached the time limit.                                                                                                                             |
|LoopInterval      |The amount of time to wait on each loop iteration.                                                                                                                              |
|Exception         |The exception which caused the loop break. This result can be null in case of no exceptions did occur.                                                                          |
|PropagateException|Propagates the exception instead of handling it.                                                                                                                                |
|Timer             |Determines for how long the loop iterations must happen. Its value is checked after each iteration. The current iteration of the loop is not interrupted when the timer has end.|


!!! info "Related Activies"
    - [Container](Container.md)
    - [Exit](Exit.md) 
    - [Iterate](Iterate.md)
    - [Next](Next.md)    
