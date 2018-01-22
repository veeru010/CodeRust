using System;

namespace CodeRust.LinkedList
{
  public static class FindNthLastNodeTest
  {
    public static void Run()
    {
      ListNode<int> head = new ListNode<int>(7);
      ListNode<int> node1 = new ListNode<int>(14);
      head.Next = node1;
      ListNode<int> node2 = new ListNode<int>(21);
      node1.Next = node2;
      ListNode<int> node3 = new ListNode<int>(28);
      node2.Next = node3;
      ListNode<int> node4 = new ListNode<int>(35);
      node3.Next = node4;
      ListNode<int> node5 = new ListNode<int>(42);
      node4.Next = node5;
      Console.WriteLine("Input :");
      head.Display();
      FindNthLastNode fl = new FindNthLastNode();
      var nNode = fl.Get<int>(head,3);
      Console.WriteLine($"3 node from last {nNode?.NodeValue}");
    }
  }

  public class FindNthLastNode
  {
    public ListNode<T> Get<T>(ListNode<T> head,int n)
    {
      if(head == null || n == 0) return null;
      var slowPointer = head;
      var fastPointer = head;
      int counter = 0;

      while(counter < n && fastPointer != null)
      {
        fastPointer = fastPointer.Next;
        counter++;
      }

      while(fastPointer != null)
      {
        fastPointer = fastPointer.Next;
        slowPointer = slowPointer.Next;
      }

      return slowPointer;
    }
  }
}