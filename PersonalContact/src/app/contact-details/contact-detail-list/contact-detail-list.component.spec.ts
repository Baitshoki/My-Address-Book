import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactDetailListComponent } from './contact-detail-list.component';

describe('ContactDetailListComponent', () => {
  let component: ContactDetailListComponent;
  let fixture: ComponentFixture<ContactDetailListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContactDetailListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactDetailListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
