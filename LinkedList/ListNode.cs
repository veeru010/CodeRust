using System;
using System.Collections.Generic;

namespace CodeRust.LinkedList
{
  public class ListNode<T>
  {
    public ListNode():this(default(T)){}
    public ListNode(T nodeVal){this.NodeValue = nodeVal;}
    public T NodeValue {get;set;}
    public ListNode<T> Next {get;set;}
  }

  public static class ListNodeExtensions
  {
    public static void Display<T>(this ListNode<T> head)
    {
      var pointer = head;
      while(pointer != null)
      {
        Console.Write($"{pointer.NodeValue} =>");
        pointer =  pointer.Next;
      }

      Console.WriteLine($"NULL");
    }

    public static ListNode<T> Reverse<T>(this ListNode<T> head)
    {
      if(head == null || head.Next == null) return head;

      ListNode<T> dummy = new ListNode<T>();
      dummy.Next = head;
      head = head.Next;
      dummy.Next.Next = null;

      while(head != null)
      {
        var temp = head;
        head = head.Next;
        temp.Next = dummy.Next;
        dummy.Next = temp;
      }

      return dummy.Next;
    }

    public static ListNode<T> Distinct<T>(this ListNode<T> head) where T : IEquatable<T>
    {
      if(head == null || head.Next == null) return head;

      HashSet<T> nodeSet = new HashSet<T>();
      nodeSet.Add(head.NodeValue);

      var pointer = head.Next;
      var prev = head;

      while(pointer != null)
      {
        if(!nodeSet.Contains(pointer.NodeValue))
        {
          nodeSet.Add(pointer.NodeValue);
          prev = prev.Next;
        }
        else
        {
          prev.Next = pointer.Next;
        }

        pointer = pointer.Next;
      }

      return head;
    }

    public static ListNode<T> Sort<T>(this ListNode<T> head) where T : IComparable<T>
    {
      if(head == null || head.Next == null) return head;

      var sortedListHead = head;
      head = head.Next;
      sortedListHead.Next = null;

      while(head != null)
      {
        var temp = head;
        head = head.Next;
        ListNode<T> prev = null;
        ListNode<T> pointer = sortedListHead;

        while(pointer != null)
        {
          if(pointer.NodeValue.CompareTo(temp.NodeValue) > 0)
          {
            if(prev == null)
            {
              sortedListHead = temp;
            }
            else
            {
              prev.Next = temp;
            }

            temp.Next = pointer;
            break;
          }

          prev = pointer;
          pointer = pointer.Next;
        }

        if(pointer == null)
        {
          prev.Next = temp;
          temp.Next = null;
        }
      }

      return sortedListHead;
    }

    public static ListNode<T> Swap<T>(this ListNode<T> head,int n)
    {
      if(head == null || n == 0) return head;
      int counter = 0;
      var pointer = head;
      ListNode<T> prev = null;

      while(pointer != null && counter < n)
      {
        prev = pointer;
        pointer = pointer.Next;
        counter++;
      }

      if(pointer == null) return null;
      var temp = head.Next;
      head.Next = pointer.Next;
      prev.Next = head;
      pointer.Next = temp;
      return pointer;
    }
  }
}