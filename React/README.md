## React Questions and Answers

**1. What is React?**

**React** is an **open-source**, **component-based** JavaScript library for building user interfaces, primarily for **single-page** applications.
It allows developers to create large web applications that can change data,**without reloading the page**.

**2. What are the key features of React? ✨**

- **Component-Based Architecture**: React applications are built using isolated, reusable components.
- **Virtual DOM**: React uses a Virtual DOM for efficient UI updates, leading to improved performance.
- **One-way Data Binding**: It allow only one-way data binding.
- **Unidirectional Data Flow**: Data flows in a single direction, typically from parent to child components, making state management predictable.
- **JSX**: A syntax extension that allows you to write HTML-like code within JavaScript.
- **Declarative UI**: You describe what the UI should look like, and React handles how to render it.

**3. Explain the Virtual DOM and how React uses it. 💡**

The **Virtual DOM** (VDOM) is a **lightweight in-memory representation** of the actual Document Object Model (DOM). When a component's **state or props** change, React first updates its **internal Virtual DOM**. It then **compares** this new Virtual DOM with the previous one (a process called **reconciliation**) and **calculates the minimal set of changes needed**. Finally, it updates **only those specific changed parts of the real DOM**, which is much faster than directly manipulating the entire DOM.

**4. What is JSX? Why do we use it? 📄**

**JSX (JavaScript XML)** is a syntax extension for JavaScript that allows you **to write HTML-like code directly within your JavaScript files**. It's not mandatory to use JSX with React, but it makes writing UI much more intuitive and readable. Browsers cannot directly understand JSX, so it's **transpiled** into regular JavaScript by tools like Babel before being executed.
```
const name = "Learner";
const element = (
    <h1>
        Hello,
        {name}.Welcome to GeeksforGeeks.
    </h1>
);
```
