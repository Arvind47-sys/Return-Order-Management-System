import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcessingChargeDetailsComponent } from './processing-charge-details.component';

describe('ProcessingChargeDetailsComponent', () => {
  let component: ProcessingChargeDetailsComponent;
  let fixture: ComponentFixture<ProcessingChargeDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProcessingChargeDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProcessingChargeDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
