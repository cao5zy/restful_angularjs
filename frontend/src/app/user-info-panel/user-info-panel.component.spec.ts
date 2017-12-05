import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserInfoPanelComponent } from './user-info-panel.component';

describe('UserInfoPanelComponent', () => {
  let component: UserInfoPanelComponent;
  let fixture: ComponentFixture<UserInfoPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserInfoPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserInfoPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
