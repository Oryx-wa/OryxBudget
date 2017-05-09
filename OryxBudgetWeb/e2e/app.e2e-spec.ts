import { NexusBudgetMgrWebPage } from './app.po';

describe('nexus-budget-mgr-web App', () => {
  let page: NexusBudgetMgrWebPage;

  beforeEach(() => {
    page = new NexusBudgetMgrWebPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
