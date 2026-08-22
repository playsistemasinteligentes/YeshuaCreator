import fs from "node:fs/promises";
import { Presentation, PresentationFile } from "@oai/artifact-tool";

const OUT = "C:/Users/AngeloRicardoFontana/source/repos/YeshuaCreator/output/presentations";
const QA = "C:/Users/AngeloRicardoFontana/source/repos/YeshuaCreator/tmp/presentations/rendered";

const C = {
  canvas: "#FFFFFF",
  ink: "#172126",
  muted: "#657177",
  panel: "#EEF1F2",
  rule: "#C9D0D3",
  green: "#0B7A3E",
  greenLight: "#E8F4ED",
  blue: "#246BCE",
  blueLight: "#EAF2FD",
  red: "#B33232",
  amber: "#B46A00",
};

const deck = Presentation.create({ slideSize: { width: 1280, height: 720 } });

function addText(slide, name, text, position, style = {}) {
  const shape = slide.shapes.add({
    geometry: "textbox",
    name,
    position,
    fill: "none",
    line: { style: "solid", fill: "none", width: 0 },
  });
  shape.text = text;
  shape.text.style = {
    fontFamily: "Arial",
    fontSize: 22,
    color: C.ink,
    verticalAlignment: "middle",
    ...style,
  };
  return shape;
}

function addBox(slide, name, position, fill, line = C.rule, radius = "none") {
  return slide.shapes.add({
    geometry: radius === "none" ? "rect" : "roundRect",
    name,
    position,
    fill,
    line: { style: "solid", fill: line, width: 1 },
    ...(radius === "none" ? {} : { borderRadius: radius }),
  });
}

function addRule(slide, name, left, top, width, fill = C.rule, height = 2) {
  return addBox(slide, name, { left, top, width, height }, fill, fill);
}

function addHeader(slide, title, section, index) {
  addText(slide, `section-${index}`, section.toUpperCase(), { left: 72, top: 32, width: 390, height: 28 }, {
    fontSize: 14,
    bold: true,
    color: C.green,
  });
  addText(slide, `title-${index}`, title, { left: 72, top: 76, width: 1110, height: 72 }, {
    fontSize: 39,
    bold: true,
    color: C.ink,
  });
  addRule(slide, `title-rule-${index}`, 72, 160, 1136, C.rule, 1);
}

function addFooter(slide, index) {
  addText(slide, `brand-${index}`, "by Play Sistemas Inteligentes", { left: 72, top: 674, width: 340, height: 22 }, {
    fontSize: 12,
    color: C.muted,
  });
  addText(slide, `page-${index}`, String(index).padStart(2, "0"), { left: 1140, top: 674, width: 68, height: 22 }, {
    fontSize: 12,
    color: C.muted,
    alignment: "right",
  });
}

function bulletsText(items) {
  return items.map((item) => `• ${item}`).join("\n");
}

function addStandardSlide(title, section, index) {
  const slide = deck.slides.add();
  slide.background.fill = C.canvas;
  addHeader(slide, title, section, index);
  addFooter(slide, index);
  return slide;
}

// 1. Cover
{
  const slide = deck.slides.add();
  slide.background.fill = C.canvas;
  addBox(slide, "cover-green-band", { left: 0, top: 0, width: 26, height: 720 }, C.green, C.green);
  addText(slide, "cover-eyebrow", "PADRAO DE SUPORTABILIDADE OPERACIONAL", { left: 88, top: 80, width: 720, height: 32 }, {
    fontSize: 16,
    bold: true,
    color: C.green,
  });
  addText(slide, "cover-title", "Requisitos mínimos\npara suporte", { left: 88, top: 160, width: 720, height: 190 }, {
    fontSize: 62,
    bold: true,
    color: C.ink,
  });
  addText(slide, "cover-subtitle", "Uma base comum para investigar, corrigir e evoluir sistemas legados com evidências verificáveis.", { left: 88, top: 382, width: 660, height: 100 }, {
    fontSize: 25,
    color: C.muted,
  });
  addText(slide, "cover-seven", "7", { left: 910, top: 116, width: 220, height: 270 }, {
    fontSize: 188,
    bold: true,
    color: C.green,
    alignment: "center",
  });
  addText(slide, "cover-seven-label", "gates mínimos", { left: 888, top: 370, width: 260, height: 46 }, {
    fontSize: 22,
    bold: true,
    color: C.ink,
    alignment: "center",
  });
  addRule(slide, "cover-rule", 88, 576, 1060, C.rule, 1);
  addText(slide, "cover-brand", "by Play Sistemas Inteligentes", { left: 88, top: 606, width: 420, height: 32 }, {
    fontSize: 18,
    bold: true,
    color: C.blue,
  });
}

// 2. Premise
{
  const slide = addStandardSlide("Suporte começa com evidência", "A premissa", 2);
  addText(slide, "premise-claim", "Conhecer o sistema não substitui a capacidade de provar o que aconteceu.", { left: 72, top: 204, width: 650, height: 130 }, {
    fontSize: 36,
    bold: true,
    color: C.ink,
  });
  addText(slide, "premise-body", "O atendimento precisa partir de uma operação real, identificar a versão executada e chegar ao código-fonte correto sem depender de memória, acesso improvisado ao servidor ou tentativa e erro.", { left: 72, top: 366, width: 650, height: 150 }, {
    fontSize: 22,
    color: C.muted,
  });
  addBox(slide, "premise-panel", { left: 800, top: 210, width: 350, height: 350 }, C.greenLight, C.green);
  addText(slide, "premise-arrow-1", "OPERAÇÃO", { left: 842, top: 246, width: 266, height: 40 }, { fontSize: 19, bold: true, color: C.green, alignment: "center" });
  addRule(slide, "premise-r1", 910, 300, 130, C.green, 3);
  addText(slide, "premise-arrow-2", "VERSÃO", { left: 842, top: 324, width: 266, height: 40 }, { fontSize: 19, bold: true, color: C.green, alignment: "center" });
  addRule(slide, "premise-r2", 910, 378, 130, C.green, 3);
  addText(slide, "premise-arrow-3", "EVIDÊNCIAS", { left: 842, top: 402, width: 266, height: 40 }, { fontSize: 19, bold: true, color: C.green, alignment: "center" });
  addRule(slide, "premise-r3", 910, 456, 130, C.green, 3);
  addText(slide, "premise-arrow-4", "CÓDIGO", { left: 842, top: 480, width: 266, height: 40 }, { fontSize: 19, bold: true, color: C.green, alignment: "center" });
}

// 3. Scope
{
  const slide = addStandardSlide("O suporte é homologado por operação", "Escopo", 3);
  addText(slide, "scope-intro", "Não é necessário instrumentar todo o sistema de uma vez. É necessário declarar com precisão o que está coberto.", { left: 72, top: 194, width: 1030, height: 70 }, {
    fontSize: 25,
    bold: true,
  });
  addRule(slide, "scope-axis", 170, 360, 900, C.rule, 4);
  const nodes = [
    ["Entrada", "API, tela, fila ou job"],
    ["Fluxo", "etapas e dependências"],
    ["Resultado", "técnico e de negócio"],
    ["Evidência", "versão, erro e fonte"],
  ];
  nodes.forEach(([name, desc], i) => {
    const x = 90 + i * 290;
    addBox(slide, `scope-node-${i}`, { left: x, top: 318, width: 200, height: 88 }, i === 3 ? C.greenLight : C.panel, i === 3 ? C.green : C.rule);
    addText(slide, `scope-node-title-${i}`, name, { left: x + 14, top: 328, width: 172, height: 30 }, { fontSize: 21, bold: true, color: i === 3 ? C.green : C.ink, alignment: "center" });
    addText(slide, `scope-node-desc-${i}`, desc, { left: x + 14, top: 360, width: 172, height: 34 }, { fontSize: 15, color: C.muted, alignment: "center" });
  });
  addText(slide, "scope-footer-claim", "Operações excluídas aparecem explicitamente no termo de homologação.", { left: 72, top: 500, width: 1050, height: 60 }, {
    fontSize: 26,
    bold: true,
    color: C.blue,
    alignment: "center",
  });
}

// 4. Gates overview
{
  const slide = addStandardSlide("Sete gates tornam o sistema suportável", "Critério de entrada", 4);
  const gates = [
    ["G1", "Governança"], ["G2", "Fonte e versão"], ["G3", "Identidade"],
    ["G4", "Evidência"], ["G5", "Consulta"], ["G6", "Diagnóstico"], ["G7", "Demonstração"],
  ];
  gates.forEach(([code, label], i) => {
    const x = 56 + i * 168;
    addBox(slide, `gate-${code}`, { left: x, top: 250, width: 148, height: 210 }, i === 6 ? C.green : C.panel, i === 6 ? C.green : C.rule);
    addText(slide, `gate-code-${code}`, code, { left: x + 16, top: 276, width: 116, height: 58 }, {
      fontSize: 36,
      bold: true,
      color: i === 6 ? C.canvas : C.green,
      alignment: "center",
    });
    addText(slide, `gate-label-${code}`, label, { left: x + 14, top: 356, width: 120, height: 58 }, {
      fontSize: 18,
      bold: true,
      color: i === 6 ? C.canvas : C.ink,
      alignment: "center",
    });
  });
  addText(slide, "gates-claim", "Todos precisam de evidência executada. Ferramenta instalada, sozinha, não comprova conformidade.", { left: 150, top: 520, width: 980, height: 70 }, {
    fontSize: 24,
    bold: true,
    color: C.ink,
    alignment: "center",
  });
}

// 5. G1/G2
{
  const slide = addStandardSlide("Sem fonte confirmada, não há diagnóstico confiável", "G1 + G2", 5);
  addBox(slide, "g12-left", { left: 72, top: 205, width: 500, height: 386 }, C.panel, C.rule);
  addText(slide, "g12-left-title", "G1  Governança", { left: 104, top: 232, width: 420, height: 44 }, { fontSize: 26, bold: true, color: C.green });
  addText(slide, "g12-left-body", bulletsText([
    "escopo por operação",
    "responsáveis identificados",
    "acessos e restrições",
    "runbook inicial",
  ]), { left: 104, top: 300, width: 410, height: 220 }, { fontSize: 21, color: C.ink });
  addBox(slide, "g12-right", { left: 632, top: 205, width: 576, height: 386 }, C.greenLight, C.green);
  addText(slide, "g12-right-title", "G2  Fonte e versão", { left: 668, top: 232, width: 492, height: 44 }, { fontSize: 26, bold: true, color: C.green });
  addText(slide, "g12-right-body", bulletsText([
    "repositório e build documentados",
    "commit ou build confirmado",
    "snapshot indexado",
    "mesma versão exposta no runtime",
    "working tree nunca representa produção",
  ]), { left: 668, top: 292, width: 490, height: 250 }, { fontSize: 21, color: C.ink });
}

// 6. G3/G4
{
  const slide = addStandardSlide("Cada execução precisa contar sua própria história", "G3 + G4", 6);
  addText(slide, "g34-identities", "RootOperationId\nOperationId\nExecutionId\nCausationId", { left: 92, top: 226, width: 320, height: 250 }, {
    fontSize: 30,
    bold: true,
    color: C.green,
    alignment: "center",
  });
  addRule(slide, "g34-separator", 454, 220, 2, C.rule, 350);
  addText(slide, "g34-body-title", "G4 transforma IDs em evidência útil", { left: 520, top: 220, width: 650, height: 55 }, { fontSize: 27, bold: true });
  addText(slide, "g34-body", bulletsText([
    "D0 em todas as operações cobertas",
    "D1 nos fluxos prioritários",
    "resultado técnico separado do resultado de negócio",
    "erro com componente, versão e stack quando possível",
    "dados classificados antes da captura",
  ]), { left: 520, top: 300, width: 650, height: 250 }, { fontSize: 21, color: C.ink });
  addText(slide, "g34-note", "Os IDs são sempre produzidos. A profundidade pode ser seletiva.", { left: 138, top: 526, width: 968, height: 48 }, { fontSize: 23, bold: true, color: C.blue, alignment: "center" });
}

// 7. G5/G6
{
  const slide = addStandardSlide("Diagnóstico profundo deve ser direcionado", "G5 + G6", 7);
  addBox(slide, "g56-baseline", { left: 72, top: 214, width: 770, height: 110 }, C.panel, C.rule);
  addText(slide, "g56-baseline-title", "BASELINE  D0 / D1", { left: 100, top: 232, width: 260, height: 34 }, { fontSize: 22, bold: true, color: C.ink });
  addText(slide, "g56-baseline-body", "Todos os fluxos cobertos permanecem consultáveis por OperationId.", { left: 380, top: 229, width: 430, height: 46 }, { fontSize: 20, color: C.muted });
  addBox(slide, "g56-target", { left: 72, top: 354, width: 1030, height: 142 }, C.greenLight, C.green);
  addText(slide, "g56-target-title", "D2 DIRECIONADO", { left: 102, top: 382, width: 260, height: 34 }, { fontSize: 22, bold: true, color: C.green });
  addText(slide, "g56-target-body", "Ativado por operação, registro, usuário técnico ou correlation ID. Sempre com prazo, limite de volume, campos autorizados e auditoria.", { left: 380, top: 368, width: 680, height: 96 }, { fontSize: 20, color: C.ink });
  addText(slide, "g56-not-global", "Debug global e permanente aumenta custo, risco e ruído. Não é o objetivo.", { left: 164, top: 548, width: 900, height: 54 }, { fontSize: 25, bold: true, color: C.red, alignment: "center" });
}

// 8. G7
{
  const slide = addStandardSlide("O fabricante demonstra, o suporte verifica", "G7", 8);
  const tests = [
    ["01", "Sucesso", "Reconstruir o fluxo completo."],
    ["02", "Rejeição", "Distinguir negócio de sucesso técnico."],
    ["03", "Falha", "Investigar erro real ou controlado."],
    ["04", "Código", "Chegar ao snapshot e aos fontes corretos."],
  ];
  tests.forEach(([num, title, desc], i) => {
    const y = 206 + i * 102;
    addText(slide, `g7-num-${i}`, num, { left: 92, top: y, width: 70, height: 58 }, { fontSize: 34, bold: true, color: C.green, alignment: "center" });
    addRule(slide, `g7-rule-${i}`, 180, y + 26, 90, C.green, 3);
    addText(slide, `g7-title-${i}`, title, { left: 300, top: y, width: 230, height: 58 }, { fontSize: 25, bold: true });
    addText(slide, `g7-desc-${i}`, desc, { left: 560, top: y, width: 570, height: 58 }, { fontSize: 21, color: C.muted });
  });
}

// 9. Depth model
{
  const slide = addStandardSlide("A profundidade cresce com a necessidade", "Modelo D0-D4", 9);
  const levels = [
    ["D0", "Essencial", 300, C.panel],
    ["D1", "Narrativa", 390, C.greenLight],
    ["D2", "Diagnóstico", 480, C.blueLight],
    ["D3", "Forense", 570, "#F8EEE0"],
    ["D4", "Reprodução", 660, "#F6E7E7"],
  ];
  levels.forEach(([code, label, width, fill], i) => {
    const y = 210 + i * 76;
    addBox(slide, `depth-${code}`, { left: 84, top: y, width, height: 58 }, fill, i < 2 ? C.green : C.rule);
    addText(slide, `depth-code-${code}`, code, { left: 104, top: y + 5, width: 72, height: 46 }, { fontSize: 23, bold: true, color: C.ink });
    addText(slide, `depth-label-${code}`, label, { left: 190, top: y + 5, width: width - 120, height: 46 }, { fontSize: 21, color: C.ink });
  });
  addText(slide, "depth-entry", "Obrigatório na entrada", { left: 810, top: 236, width: 300, height: 50 }, { fontSize: 24, bold: true, color: C.green, alignment: "center" });
  addText(slide, "depth-advanced", "Evolução de maturidade", { left: 810, top: 438, width: 300, height: 50 }, { fontSize: 24, bold: true, color: C.blue, alignment: "center" });
  addRule(slide, "depth-split", 960, 304, 2, C.rule, 108);
}

// 10. Manufacturer deliverables
{
  const slide = addStandardSlide("O fabricante entrega capacidade, não um produto específico", "Entregáveis", 10);
  const left = [
    "repositório e build",
    "versão no runtime",
    "catálogo de operações",
    "instrumentação D0 / D1",
  ];
  const right = [
    "consulta por OperationId",
    "D2 direcionado",
    "classificação de dados",
    "demonstração G7",
  ];
  addText(slide, "deliver-left", bulletsText(left), { left: 96, top: 225, width: 470, height: 280 }, { fontSize: 24, color: C.ink });
  addText(slide, "deliver-right", bulletsText(right), { left: 650, top: 225, width: 470, height: 280 }, { fontSize: 24, color: C.ink });
  addBox(slide, "deliver-callout", { left: 178, top: 532, width: 924, height: 74 }, C.green, C.green);
  addText(slide, "deliver-callout-text", "A tecnologia pode variar. A evidência mínima, não.", { left: 214, top: 542, width: 852, height: 52 }, { fontSize: 27, bold: true, color: C.canvas, alignment: "center" });
}

// 11. Security
{
  const slide = addStandardSlide("Mais detalhe não pode significar mais exposição", "Dados e segurança", 11);
  const classes = [
    ["SafeMetadata", "baseline", C.greenLight, C.green],
    ["OperationalData", "conforme política", C.blueLight, C.blue],
    ["Sensitive", "explícito, mascarado e temporário", "#F8EEE0", C.amber],
    ["NeverCapture", "senhas, tokens, chaves e certificados", "#F6E7E7", C.red],
  ];
  classes.forEach(([name, desc, fill, accent], i) => {
    const y = 212 + i * 94;
    addBox(slide, `data-${i}`, { left: 92, top: y, width: 1030, height: 70 }, fill, accent);
    addText(slide, `data-name-${i}`, name, { left: 120, top: y + 10, width: 280, height: 48 }, { fontSize: 23, bold: true, color: accent });
    addText(slide, `data-desc-${i}`, desc, { left: 430, top: y + 10, width: 650, height: 48 }, { fontSize: 21, color: C.ink });
  });
}

// 12. Onboarding
{
  const slide = addStandardSlide("A adequação acontece em nove movimentos", "Onboarding", 12);
  const steps = ["Escopo", "Gaps", "Plano", "Índice", "D0/D1", "Coletor", "D2", "Demonstração", "Homologação"];
  steps.forEach((label, i) => {
    const row = i < 5 ? 0 : 1;
    const col = row === 0 ? i : i - 5;
    const x = row === 0 ? 70 + col * 230 : 185 + col * 230;
    const y = row === 0 ? 240 : 410;
    addBox(slide, `onboard-${i}`, { left: x, top: y, width: 190, height: 76 }, i === 8 ? C.green : C.panel, i === 8 ? C.green : C.rule);
    addText(slide, `onboard-label-${i}`, `${String(i + 1).padStart(2, "0")}  ${label}`, { left: x + 12, top: y + 10, width: 166, height: 54 }, { fontSize: 19, bold: true, color: i === 8 ? C.canvas : C.ink, alignment: "center" });
  });
  addText(slide, "onboard-note", "EM ADEQUAÇÃO permite onboarding. O SLA normal começa após G1-G7.", { left: 170, top: 552, width: 940, height: 56 }, { fontSize: 24, bold: true, color: C.blue, alignment: "center" });
}

// 13. Classification
{
  const slide = addStandardSlide("A classificação deixa o compromisso explícito", "Resultado", 13);
  const states = [
    ["NÃO ELEGÍVEL", "Falha em requisito obrigatório", C.red],
    ["EM ADEQUAÇÃO", "Plano ativo, sem SLA normal", C.amber],
    ["ELEGÍVEL", "G1 a G7 comprovados no escopo", C.green],
    ["AVANÇADO", "D3/D4, replay ou prevenção", C.blue],
  ];
  states.forEach(([name, desc, accent], i) => {
    const y = 214 + i * 98;
    addRule(slide, `state-accent-${i}`, 92, y, 10, accent, 72);
    addText(slide, `state-name-${i}`, name, { left: 128, top: y + 2, width: 300, height: 58 }, { fontSize: 24, bold: true, color: accent });
    addText(slide, `state-desc-${i}`, desc, { left: 470, top: y + 2, width: 640, height: 58 }, { fontSize: 21, color: C.ink });
  });
}

// 14. Close
{
  const slide = deck.slides.add();
  slide.background.fill = C.ink;
  addText(slide, "close-eyebrow", "O CRITÉRIO FINAL", { left: 90, top: 80, width: 400, height: 32 }, { fontSize: 16, bold: true, color: "#76D39B" });
  addText(slide, "close-title", "Uma equipe que não escreveu o sistema consegue explicar a falha.", { left: 90, top: 160, width: 940, height: 190 }, { fontSize: 50, bold: true, color: C.canvas });
  addText(slide, "close-body", "Ela reconstrói a operação, identifica a versão, localiza os fontes relevantes e apresenta evidências verificáveis.", { left: 90, top: 390, width: 850, height: 110 }, { fontSize: 25, color: "#D8DEE1" });
  addRule(slide, "close-rule", 90, 566, 1000, "#4D5A60", 1);
  addText(slide, "close-brand", "by Play Sistemas Inteligentes", { left: 90, top: 600, width: 450, height: 38 }, { fontSize: 20, bold: true, color: "#76D39B" });
  addText(slide, "close-action", "Próximo passo: definir o escopo da avaliação.", { left: 690, top: 594, width: 430, height: 50 }, { fontSize: 20, color: C.canvas, alignment: "right" });
}

async function writeBlob(path, blob) {
  await fs.writeFile(path, new Uint8Array(await blob.arrayBuffer()));
}

await fs.mkdir(OUT, { recursive: true });
await fs.mkdir(QA, { recursive: true });

for (const [index, slide] of deck.slides.items.entries()) {
  const stem = `slide-${String(index + 1).padStart(2, "0")}`;
  await writeBlob(`${QA}/${stem}.png`, await deck.export({ slide, format: "png", scale: 1 }));
  const layout = await slide.export({ format: "layout" });
  await fs.writeFile(`${QA}/${stem}.layout.json`, await layout.text());
}

await writeBlob(`${QA}/montage.webp`, await deck.export({ format: "webp", montage: true, scale: 1 }));
const pptx = await PresentationFile.exportPptx(deck);
await pptx.save(`${OUT}/Legados_Requisitos_Minimos_Para_Suporte.pptx`);

console.log(`${OUT}/Legados_Requisitos_Minimos_Para_Suporte.pptx`);
