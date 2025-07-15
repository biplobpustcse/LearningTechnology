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
**5. What are Props in React? 📦**

**Props** (short for properties) are **read-only attributes** passed from a **parent component to a child component**. They allow data and event handlers to flow down the component tree, enabling components to be reusable and customizable. **Props are immutable**, meaning a child component cannot directly modify the props it receives from its parent.

**6. What is State in React? 🔄**

**State** is an object managed within a component that **holds data** that can change over time and influences the component's rendering and behavior. Unlike props, state is **mutable** and is typically managed internally by the component itself. When the state changes, React re-renders the component.

**7. Differentiate between Props and State. ⚖️**

| Props (properties) | State                    |
| ------------------ | ------------------------ |
| Managed By Parent component | By Component itself |
| Immutable (Read-only) | Mutable (can be changed) |
| Passed from parent | Managed within component |
| External data      | Internal data            |

**7. How to pass data from parent to child component?**

Using **props**.
```
<ChildComponent name="Biplob" />
```

**8. What are components in React?**

**React components** are the **building blocks** of a React application. There are two types:

- **Functional Components** – use **hooks**, written as functions.

These are simple JavaScript functions that accept **props** as an argument and return React elements (JSX). Before React Hooks, they were often called "stateless functional components" because they couldn't manage their own state. Now, with Hooks, they can be stateful.
- **Class Components** – use **this** and **lifecycle methods**.

These are ES6 classes that extend React.Component. They can hold and manage their own state using this.state and this.setState(), and they have access to lifecycle methods.

**9. What are React Hooks? Explain useState and useEffect Hooks.**

React Hooks **are functions** introduced in **React 16.8** that allow you to use **state and lifecycle features** in functional components. Hooks like **useState, useEffect, and useContext** make it easier to manage component logic without using classes, improving readability and reusability.

- **useState**: This hook allows you to add **state** to functional components. It returns an array containing the current state value and a function to update it.
- **useEffect**: This hook lets you perform **side effects** in functional components. Side effects are operations that interact with something **outside of the component's rendering**, such as data fetching, subscriptions, or manually changing the DOM. It runs after every render by default.
```
import React, { useState, useEffect } from 'react';

function Counter() {
  const [count, setCount] = useState(0);

  useEffect(() => {
    console.log('Count changed:', count);
  }, [count]);

  return (
    <div>
      <button onClick={() => setCount(count + 1)}>Increment</button>
    </div>
  );
}
```
**10. What are the rules of Hooks? 📜**

There are two main rules for using Hooks:

- **Only call Hooks at the top level**: Don't call Hooks inside loops, conditions, or nested functions.
- **Only call Hooks from React function**s: Call them from React functional components or from custom Hooks.

**11. What is "lifting state up" in React? ⬆️**

**Lifting state up** is a technique where you move the state from a child component to its closest common parent component. This allows multiple child components to share and synchronize their state. The parent component then passes the state and functions to update that state down to its children via props.

**11. What is context API in React?**

Context provides a way to **pass data** through the **component tree** without passing **props** manually at every level.
```
const MyContext = React.createContext();
<MyContext.Provider value={value}>
  <MyComponent />
</MyContext.Provider>
```
**12. How does React handle reconciliation?**

React compares the new Virtual DOM with the previous one (diffing) and updates only the parts of the actual DOM that changed (reconciliation).

**13. What are Higher-Order Components (HOC)?**

A HOC is a function that takes a component and returns a new component with enhanced behavior.
```
function withLogger(Component) {
  return function Enhanced(props) {
    console.log('Rendering', Component.name);
    return <Component {...props} />;
  }
}
```
**14. What is React Router and why is it used? 🗺️**

**React Router** is a standard library for routing in React applications. It enables you to create Single Page Applications (SPAs) with multiple views and allows for programmatic navigation. It keeps the UI in sync with the URL, providing a consistent user experience **without full page reloads**.
```
<Route path="/about" element={<About />} />
```
**15. How do you handle forms in React?**

Using controlled components, managing state with **useState**, and handling **onSubmit**.
```
<form onSubmit={handleSubmit}>
  <input value={name} onChange={e => setName(e.target.value)} />
</form>
```
**17. How does React handle reconciliation?**

React compares the new Virtual DOM with the previous one (diffing) and updates only the parts of the actual DOM that changed (reconciliation).

**18. What is lazy loading in React?**

Lazy loading means loading components only when needed using **React.lazy** and **Suspense**.
```
const LazyComponent = React.lazy(() => import('./LazyComponent'));

<Suspense fallback={<div>Loading...</div>}>
  <LazyComponent />
</Suspense>
```
**19. What is controlled vs uncontrolled component?**
| Controlled                    | Uncontrolled                    |
| ----------------------------- | ------------------------------- |
| Form data is handled by React | Form data is handled by the DOM |
| Uses `useState`               | Uses `ref`                      |

```
// Controlled
<input value={value} onChange={e => setValue(e.target.value)} />

// Uncontrolled
<input ref={inputRef} />
```
**20. What is useMemo and useCallback?**

- **useMemo**: Caches expensive calculations.
```
const result = useMemo(() => expensiveCalculation(a, b), [a, b]);
```
- **useCallback**: Caches function instances.
```
const handleClick = useCallback(() => doSomething(), []);
```
**21. What is Axios interceptors in React**

How to add a JWT (JSON Web Token) to the header of HTTP requests in a React application?

To automatically add a JWT token to the header of all HTTP requests in a React application, the most common and maintainable method is to use Axios interceptors.
This ensures that the token is automatically included in all outgoing requests without needing to manually add it to each one.

**Create an Axios Instance**

Create a reusable axios.js file (or axiosInstance.js) to configure the base URL and attach the token.
```
// src/api/axios.js
import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://your-api-domain.com/api', // Set your API base URL
});

// Request interceptor to add JWT token
axiosInstance.interceptors.request.use(
  config => {
    const token = localStorage.getItem('jwtToken'); // or from Redux, Context, or Cookies

    if (token) {
      config.headers['Authorization'] = `Bearer ${token}`;
    }

    return config;
  },
  error => {
    return Promise.reject(error);
  }
);

export default axiosInstance;
```
**Use Axios Instance in Your Components or Services**
```
// src/services/userService.js
import axios from '../api/axios';

export const getUserProfile = async () => {
  const response = await axios.get('/users/profile');
  return response.data;
};
```
**Store JWT Token After Login**

When you log in and receive a JWT token:
```
// src/pages/Login.js
localStorage.setItem('jwtToken', response.data.token);
```


