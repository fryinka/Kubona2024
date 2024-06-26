import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdListComponent } from './prod-list.component';

describe('ProdListComponent', () => {
  let component: ProdListComponent;
  let fixture: ComponentFixture<ProdListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
        declarations: [ ProdListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Have the grandSize of 2000', ()=>{
      expect(component.grandSize).toBeLessThanOrEqual(2000);
  });
});
