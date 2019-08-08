import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ParentChooseKingergartenComponent } from './parent-choose-kingergarten.component';

describe('ParentChooseKingergartenComponent', () => {
  let component: ParentChooseKingergartenComponent;
  let fixture: ComponentFixture<ParentChooseKingergartenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ParentChooseKingergartenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ParentChooseKingergartenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
