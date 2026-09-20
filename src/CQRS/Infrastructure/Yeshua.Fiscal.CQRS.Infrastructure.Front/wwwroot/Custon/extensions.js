window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};
window.yeshuaAppExtensionReady = import('/Custon/Apps/Fiscal/extensions.js')
    .catch(error => console.error('Falha ao carregar extensoes do aplicativo Fiscal.', error));