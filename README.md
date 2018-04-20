# FrontWork快速入门

&emsp;如果问你做前端用什么编程语言和框架，你的第一反应一定是HTML5+BootStrap，或者C#的WPF，甚至你也许还想反问一句：现在有这么多强大的框架，能解决所有的问题，能做出任何绚丽的页面。难道我们还有满足不了的需求吗？确实，无可反驳。无论是在Web端，还是在当今的桌面应用，确实已经有非常非常多的前端框架可以使用了。但是，这些前端框架没有一款能够真正解决我们开发人员每天所面对的一个重要问题。你可能会疑惑道，我每天都在机械地按照固定的模式进行着相似的开发，我早已习惯这样的工作，所以我没有思考我的工作究竟有什么样的问题？

&emsp;那么，我举个例子。

&emsp;当我们只是想要做一个普通的增删改查页面的时候，我们是希望关心增删改查哪些字段，比如"用户名"，"密码"，以及"个性签名"就够了，还是去关心每一个用户名，密码，个性签名编辑框的位置，字体，大小，颜色，边框，网页布局，输入验证，提交事件，甚至是Ajax连接呢？

&emsp;另外一个例子是最近相当流行的Markdown。

&emsp;也许有很多人知道Markdown，例如这篇文档就是用Markdown编写的。使用Markdown，当我们需要一个大号标题的时候，我们只要编写**#FrontWork快速入门** （标题前加一个井号）就能得到这篇文档的标题那样的效果，你不需要自己去设置这个标题的颜色，位置，字体等等。你所关心的只是，这里，有一个大号标题。是不是很简单？你可以想象，如果我们用HTML5来实现一个同样的标题，需要编写多少CSS样式？又需要花多长时间来调整样式，直到它成为你需要的样子？我们真的需要每天把时间花费在这些事情上吗？

&emsp;这就是为什么我要向你介绍FrontWork框架

&emsp;FrontWork是一款极为先进的轻量级MVVM前端框架，提倡配置优于实现的开发理念，利用极为简单配置文件来配置整个系统的前端业务逻辑，包括数据的展示，条件查询，数据删改，数据验证以及数据和服务器后端的同步工作。简单地说，使用FrontWork，只需要编写配置文件，就可以完成整个桌面程序。接下来，让我带你走进FrontWork的世界。

## Hello, FrontWork!

&emsp;作为入门的开始，我们就先来了解FrontWork所有组件中最容易理解，也最为前端的组件 - **View**（视图组件）
