<div id="carbonForm">
	<p>Бронирование</p>

<form action="" method="POST" id="signupForm">
<div class="fieldContainer">
<div class="formRow">
<div class="new-select-style-wpandyou">
<select required name="id_type" id="id_type"><option disabled selected>Выберите зал для съемки</option>
<?php foreach($data2 as $row) :?>                    
                            <option value="<?php echo $row['id_rooms']; ?>">
                                <?php echo $row['name']; ?>
                            </option>
                   <?php endforeach; ?>
</select>
 </div>
 </div>
<div class="formRow">
<div class="new-select-style-wpandyou">
<select required name="id_date" id="id_date"><option disabled selected>Выберите дату</option>
<?php foreach($data as $row) :?>                  
                            <option value="<?php echo $row; ?>">
                                <?php echo $row; ?>
                            </option>
                    <?php endforeach; ?>
</select>
 </div>
</div>
<div class="formRow">
<div class="new-select-style-wpandyou">
<select required name="id_time" id="id_time" onChange="chcost();" >
                    <option disabled selected>Выберите время брони</option>
                    <?php foreach($data1 as $row) :?>                  
                            <option value="<?php echo $row; ?>">
                                <?php echo $row; ?>
                            </option>
                    <?php endforeach; ?>
                </select>
		 </div>		
   </div>
        <div class="formRow">
            <div class="label">
                <label for="name">Ваша фамилия:</label>
            </div>            
            <div class="field">
                <input type="text" name="name" required id="name" placeholder="Фамилия"/>
            </div>
        </div>        
        <div class="formRow">
            <div class="label">
                <label for="email">Email:</label>
            </div>           
            <div class="field">
                <input type="text" name="email" required id="email" placeholder="Email"/>
            </div>
        </div>        
        <div class="formRow">
            <div class="label">
                <label for="nphone">Номер телефона:</label>
            </div>            
            <div class="field">
                <input type="text" name="nphone" required id="nphone" placeholder="Номер телефона" />
            </div>
        </div>                    
        <input type="submit" name="submit" id="submit" value="Забронировать" />	   
    </div>    
    </form>       
</div>
    </form>
        
</div>