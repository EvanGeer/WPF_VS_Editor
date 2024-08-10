function buildEditor(text) {
    const editor = monaco.editor.create(document.getElementById('container'), {
        theme: 'vs-dark',
        value: text,
        language: 'javascript',
        name: 'monacoEditor'
    });

    editor.getModel().onDidChangeContent((event) => {
        window.chrome.webview.postMessage(editor.getValue());
    });
}
 