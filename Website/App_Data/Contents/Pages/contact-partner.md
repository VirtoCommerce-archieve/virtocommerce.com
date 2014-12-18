---
layout: post
title: Enterprise .NET open-source ecommerce cloud platform. Contact Partner
description: Enterprise .NET open-source ecommerce cloud platform. Contact Partner
date: 2014-01-30
permalink: /pages/contact-partner
tags :
- contact-partner
- partner
- commerce
---
<article role="main" class="main">
	<div class="download responsive">
		<h2 class="title">Contact Partner</h2>
		<p class="text">Use this form to contact partner directly.</p>
		<form class="form" action="">
			<input type="hidden" value="Download SDK" name="Subject"/>
			<input type="hidden" value="true" name="IsResend"/>
			<input type="hidden" value="/thank-you" name="RedirectUrl" />
			<input type="hidden" value="" name="PartnerId" />
			<div class="control-group">
				<label for="Fullname" class="form-label">Full name:</label>
				<input type="text" class="form-input" name="Fullname" required>
			</div>
			<div class="control-group">
				<label for="To" class="form-label">Email:</label>
				<input type="text" class="form-input" name="To" required>
			</div>
			<div class="control-group">
				<label for="CompanyName" class="form-label">Company name:</label>
				<input type="text" class="form-input" name="CompanyName" required>
			</div>
			<div class="control-group">
				<label for="Kickoff" class="form-label">When do you want to kick off this project?</label>
				<select type="text" name="Kickoff" class="form-input" required>
					<option value="" selected>Select Option</option>
					<option value="immediately">Immediately</option>
					<option value="1-3 months">1-3 months</option>
					<option value="3-6 months">3-6 months</option>
					<option value="6-12 months">6-12 months</option>
					<option value="no timeframe">No timeframe</option>
				</select>
			</div>
			<div class="control-group">
				<label for="descr">Comments</label>
				<textarea rows="10" cols="30" name="Comments" class="form-text" required></textarea>
			</div>
			<div class="control-group">
				<button class="button fill" type="submit">Submit request</button>
			</div>
		</form>
	</div>
	{% include technologies.html %}
</article>