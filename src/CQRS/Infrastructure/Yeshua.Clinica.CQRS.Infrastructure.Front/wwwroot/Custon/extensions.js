window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};
window.yeshuaAppExtensionReady = import('/Custon/Apps/Clinica/extensions.js')
    .catch(error => console.error('Falha ao carregar extensoes do aplicativo Clinica.', error));