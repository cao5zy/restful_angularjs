import { MdfrontPage } from './app.po';

describe('mdfront App', () => {
  let page: MdfrontPage;

  beforeEach(() => {
    page = new MdfrontPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
