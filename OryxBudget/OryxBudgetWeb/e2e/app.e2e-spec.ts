import { OryxBudgetWebPage } from './app.po';

describe('oryx-budget-web App', () => {
  let page: OryxBudgetWebPage;

  beforeEach(() => {
    page = new OryxBudgetWebPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
