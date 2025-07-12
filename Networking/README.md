# Networking
🖥️💡 "একজন সফটওয়্যার ইঞ্জিনিয়ার হিসেবে আমাদের কাজ শুধু Code লিখলে শেষ হয়ে যাই না , আমাদের বুঝতে হবে আমাদের কোড কিভাবে পৃথিবীর এ প্রান্ত থেকে অন্য প্রান্তে ঘুরে বেড়ায়!" 🌍

Networking না বুঝলে Backend Developer-রা আধা-অন্ধকারে কাজ করে।
তো আমরা আজকে Networking একদম সহজভাবে পুরো কাহিনী বুঝে নেয়ার চেষ্টা করবো , যেন আমাদের মাথায় সেট হয়ে যায় — যাতে Interview বা Project-এ মুখ থুবড়ে পড়তে না হয়।

🛜 1. DNS (ইন্টারনেটের ফোনবুক)
আপনি যখন ব্রাউজার কোনো কিছু লিখে সার্চ করেন যেমন google.com বা mehediblog.com টাইপ করলেই Server খুঁজে পায় না।
প্রথমে DNS (Domain Name System) কে জিজ্ঞেস করা হয়:
“এই ওয়েবসাইটের আসল ঠিকানা (IP Address) কি?”
উত্তর আসে: 142.250.190.78
এখন কম্পিউটার জানে কোথায় যেতে হবে।

🛜 2. IP আর Port (বাসার ঠিকানা আর দরজা)
IP: কম্পিউটারের ইউনিক ঠিকানা।
Port: কোন দরজা দিয়ে কথা হবে সেটা।
Example:
142.250.190.78:443 → Google এর ওয়েব সার্ভার (443 মানে HTTPS দরজা বা Port)

🛜 3. TCP/UDP (কথাবার্তার মাধ্যম)
TCP(Transmission Control Protocol) :Safe, নিশ্চয়তা সহ Data পৌঁছে দেয়। (যেমন ওয়েবসাইট, API)
UDP(User Datagram Protocol): দ্রুত, কিন্তু গ্যারান্টি নাই। (যেমন Online Game, Live Stream)

🛜 4. TCP Three-Way Handshake (ভদ্রভাবে শুরু করে )
আপনি কাউকে Call দেওয়ার আগে কনফার্ম করো:-
Client: "শুনতে পাচ্ছ?" (SYN)
Server: "হ্যাঁ, শুনতে পাচ্ছি।" (SYN-ACK)
Client: "ঠিক আছে, কথা শুরু করি।" (ACK)
তারপর Data পাঠানো শুরু হয়।

🛜 5. HTTP/HTTPS (আপনার আসল Request)
আপনি যখন কোনো ডাটার জন্য রিকোয়েস্ট পাঠান :
GET /posts/5
Server সেই অনুযায়ী Data পাঠায়।
HTTPS হলে পুরো কথাবার্তা গোপনে হয়।

🛜 6. SSL/TLS (গোপন সংকেত)
আপনি যখন সার্ভার এ ডাটা পাঠাবেন এইচটিটিপি এর মাধ্যমে ডাটা কিন্তু প্লেইন টেক্সট এ থাকে সো কেউ চাইলে ডাটা হ্যাক করতে পারে , সো এই জন্য ডাটা Encryption খুব গুরুত্বপূর্ণ , Data Encrypted হলে শুধু Client আর Server বুঝবে, মাঝখানে কেউ বুঝবে না।

🛜 7. Reverse Proxy & Load Balancer (স্মার্ট দারোয়ান)
অনেক Request একসাথে এলে একটা Server একা সামলাতে পারে না।
তাই Load Balancer সব Server এর মধ্যে Divide করে দেয়।
Reverse Proxy Backend কে লুকিয়ে রাখে, নিরাপত্তা বাড়ায়।

🛜 8. Firewall (কড়া পাহারা)
সব Request ঢুকতে দেয় না।
Firewall দেখে ঠিক লোক কিনা, না হলে Block করে দেয়।

✅ সংক্ষিপ্তভাবে পুরো Flow:
Browser → DNS → Server IP → TCP Handshake → SSL/TLS → HTTP Request → Backend → Response
সবকিছু ঘটে মিলিসেকেন্ডে, কিন্তু আপনি যদি এইটা বুঝেন তাহলে:
✔ Debug সহজ
✔ Secure API বানানো সহজ
✔ Backend Architect বুঝা সহজ

[Reference:](https://www.linkedin.com/posts/lutful-mehedi_backenddevelopment-networking-banglatech-activity-7343232590411153409-BTfB?utm_source=share&utm_medium=member_desktop&rcm=ACoAABxURCsBhbj_Yo9DwdntB5c06C8bErOYSVg)

**TCP (Transmission Control Protocol)**

TCP, is a fundamental protocol within the TCP/IP suite, **ensuring reliable** and **ordered delivery** of data between applications and devices. It establishes a connection, breaks data into packets, numbers them for order, and manages retransmissions if packets are lost or corrupted. This makes TCP crucial for applications where data integrity is paramount, such as web browsing, email, and file transfer.

**UDP (User Datagram Protocol)**
UDP, is a communication protocol that prioritizes speed and efficiency over reliability. It's a connectionless protocol, meaning it doesn't require a prior connection to be established between sender and receiver before transmitting data. This makes it suitable for applications where speed is crucial, even if some data loss is acceptable. 

**TCP vs. UDP:**

While TCP is connection-oriented and reliable, UDP (User Datagram Protocol) is connectionless and faster but less reliable. UDP is often preferred for applications where speed is critical and some data loss is acceptable, like streaming or online gaming. 

**SSL (Secure Sockets Layer)**

SSL (Secure Sockets Layer) is a security protocol that creates an encrypted link between a web server and a browser, ensuring secure transmission of data between the two. It's commonly used to protect sensitive information like usernames, passwords, and credit card details transmitted online. 

**TLS (Transport Layer Security)**

TLS, or Transport Layer Security, is a cryptographic protocol that provides secure communication over a network, primarily used to encrypt internet traffic like web browsing, email, and messaging.

**HTTPS:**

Websites using SSL/TLS have "HTTPS" in their URL, instead of "HTTP," indicating a secure connection. 

**SSL vs. TLS:**

While "SSL" is commonly used, TLS is the current, upgraded version of the protocol. 

