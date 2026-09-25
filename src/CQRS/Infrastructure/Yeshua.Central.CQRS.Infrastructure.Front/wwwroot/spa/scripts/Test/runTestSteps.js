async function runCrudTest(script) {
    console.log(`▶ Iniciando: ${script.name}`);
    for (const step of script.steps) {
        switch (step.action) {
            case "click":
                document.querySelector(step.selector)?.click();
                break;

            case "clickMenuText":
                clickMenuItemByText(step.label);
                break;

            case "setValue":
                const input = document.querySelector(`#insert-${step.field}`);
                if (input) {
                    input.value = step.value;
                    input.dispatchEvent(new Event('input', { bubbles: true }));
                }
                break;

            case "wait":
                await new Promise(resolve => setTimeout(resolve, step.ms || 500));
                break;
        }

        await new Promise(resolve => setTimeout(resolve, 300));
    }
    console.log(`✅ Teste finalizado: ${script.name}`);
}

function clickMenuItemByText(textoMenu) {
    const items = document.querySelectorAll('#menu a');
    for (const item of items) {
        if (item.textContent.trim() === textoMenu) {
            item.click();
            console.log(`🧭 Menu clicado: "${textoMenu}"`);
            return true;
        }
    }
    console.warn(`❌ Menu "${textoMenu}" não encontrado`);
    return false;
}

window.runCrudTest = runCrudTest;

/*
teste via console proficional 

import { runCrudTest } from './runTestSteps.js';

const script = {
  name: "Teste CRUD",
  steps: [
    { action: "click", selector: "#btn-new" },
    { action: "setValue", field: "nome", value: "João Teste" },
    { action: "setValue", field: "idade", value: "32" },
    { action: "click", selector: "#btn-save" }
  ]
};

runCrudTest(script);



*/


