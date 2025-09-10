using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: highest priority item in middle of queue and two items with equal priority in queue
    // Expected Result: Tim, George, Sue, Bob
    // Defect(s) Found: Expected "George" got "Tim", Dequeue was not removing from the queue. Expected "Sue" got "Bob", A -1 was in the Dequeue for loop and the if statment was >= and needed to be >
    public void TestPriorityQueue_1()
    {
        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var sue = new PriorityItem("Sue", 3);
        var george = new PriorityItem("George", 3);

        PriorityItem[] expectedResult = [tim, george, sue, bob];

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(george.Value, george.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        for (int i = 0; i < 4; i++)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
        }
    }

    [TestMethod]
    // Scenario: empty queue
    // Expected Result: "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    // Add more test cases as needed below.
}