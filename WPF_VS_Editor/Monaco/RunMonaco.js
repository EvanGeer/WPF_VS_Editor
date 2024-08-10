 function buildEditor(text) {
    const editor = monaco.editor.create(document.getElementById('container'), {
        theme: 'vs-dark',
        value: text,
        language: 'javascript',
        name: 'monacoEditor'
    });

     editor.getModel().onDidChangeContent((event) => {
         //console.log("CHANGE", editor.getValue());
         window.chrome.webview.postMessage(editor.getValue());
     });

    return editor;
}

 function getText() {
    return editor.getValue();
}