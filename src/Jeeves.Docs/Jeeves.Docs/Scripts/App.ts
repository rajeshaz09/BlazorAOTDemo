namespace BlazorJavaScriptSupport {

  class ExampleClass {
    public ExampleFunction(message: string): string {
      return prompt(message, 'Type anything here');
    }
  }

  export function Load(): void {
    window['exampleClass'] = new ExampleClass();
  }

  export function NavigateToHtmlElement(identifier: string) {
    var pathName = window.location.pathname;
    window.location.hash = identifier;
    window.location.pathname = pathName;
  }

  export function ScrollToTop(identifier: string) {
    document.getElementById(identifier).scrollTop = 0;
  }
}

BlazorJavaScriptSupport.Load();