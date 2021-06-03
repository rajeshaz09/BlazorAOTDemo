var BlazorJavaScriptSupport;
(function (BlazorJavaScriptSupport) {
    class ExampleClass {
        ExampleFunction(message) {
            return prompt(message, 'Type anything here');
        }
    }
    function Load() {
        window['exampleClass'] = new ExampleClass();
    }
    BlazorJavaScriptSupport.Load = Load;
    function NavigateToHtmlElement(identifier) {
        var pathName = window.location.pathname;
        window.location.hash = identifier;
        window.location.pathname = pathName;
    }
    BlazorJavaScriptSupport.NavigateToHtmlElement = NavigateToHtmlElement;
    function ScrollToTop(identifier) {
        document.getElementById(identifier).scrollTop = 0;
    }
    BlazorJavaScriptSupport.ScrollToTop = ScrollToTop;
})(BlazorJavaScriptSupport || (BlazorJavaScriptSupport = {}));
BlazorJavaScriptSupport.Load();
//# sourceMappingURL=App.js.map