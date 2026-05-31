#include <iostream>
#include <stack>
#include <stdexcept>

class Queue
{
    private:
    std::stack<int> stack_in;  // Для push
    std::stack<int> stack_out; // Для pop/peek

    // Допоміжна функція для перенесення елементів
    void transfer()
    {
        if (stack_out.empty())
        {
            while (!stack_in.empty())
            {
                stack_out.push(stack_in.top());
                stack_in.pop();
            }
        }
    }

    // Додавання елемента 
    void enqueue(int value)
    {
        stack_in.push(value);
    }

    // Видалення елемента
    void dequeue()
    {
        if (isEmpty()) throw std::underflow_error("Queue is empty");
        transfer();
        stack_out.pop();
    }

    // Отримання переднього елемента 
    int front()
    {
        if (isEmpty()) throw std::underflow_error("Queue is empty");
        transfer();
        return stack_out.top();
    }

    bool isEmpty()
    {
        return stack_in.empty() && stack_out.empty();
    }
};

int main()
{
    Queue q;
    q.enqueue(1);
    q.enqueue(2);
    q.enqueue(3);

    std::cout << "Front: " << q.front() << std::endl; // 1
    q.dequeue();
    std::cout << "New Front: " << q.front() << std::endl; // 2

    return 0;
}